using Oxide.Core;
using Oxide.Core.Plugins;
using System;

namespace Oxide.Plugins
{
    [Info("Elastic Population", "Papa", "1.0.4")]
    [Description("Dynamically adjusts server max population based on current player count with optimized cooldown handling.")]
    public class ElasticPopulation : RustPlugin
    {
        private ConfigData configData;
        private bool timerActive = false;

        class ConfigData
        {
            public int MaxPlayersOffset { get; set; }
            public float CooldownPeriod { get; set; }
            public int MaximumPopulation { get; set; }
            public bool ConsoleMessagesEnabled { get; set; }
        }

        protected override void LoadDefaultConfig()
        {
            Puts("Creating a new configuration file.");
            configData = new ConfigData
            {
                MaxPlayersOffset = 1,
                CooldownPeriod = 10.0f,
                MaximumPopulation = 200,
                ConsoleMessagesEnabled = true
            };
            SaveConfig();
        }

        protected override void LoadConfig()
        {
            base.LoadConfig();
            configData = Config.ReadObject<ConfigData>();
            if (configData == null)
            {
                LoadDefaultConfig();
            }
        }

        protected override void SaveConfig()
        {
            Config.WriteObject(configData);
        }

        private void OnServerInitialized()
        {
            SetMaxPlayers();
        }

        private void OnPlayerConnected(BasePlayer player)
        {
            StartCooldownTimer();
        }

        private void OnPlayerDisconnected(BasePlayer player, string reason)
        {
            StartCooldownTimer();
        }

        private void SetMaxPlayers()
        {
            int currentPlayers = BasePlayer.activePlayerList.Count;
            int newMaxPlayers = Math.Max(currentPlayers + configData.MaxPlayersOffset, ConVar.Server.maxplayers);
            newMaxPlayers = Math.Min(newMaxPlayers, configData.MaximumPopulation);

            if (ConVar.Server.maxplayers != newMaxPlayers)
            {
                ConVar.Server.maxplayers = newMaxPlayers;
                if (configData.ConsoleMessagesEnabled)
                {
                    Puts($"Max players adjusted to: {newMaxPlayers}");
                }
            }
        }

        private void StartCooldownTimer()
        {
            if (!timerActive)
            {
                timerActive = true;
                timer.Once(configData.CooldownPeriod, () =>
                {
                    SetMaxPlayers();
                    timerActive = false;
                });
            }
        }
    }
}
