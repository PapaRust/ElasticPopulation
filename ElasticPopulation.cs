using Oxide.Core;
using Oxide.Core.Plugins;
using System;

namespace Oxide.Plugins
{
    [Info("ElasticPopulation", "Papa", "1.0.2")]
    [Description("Dynamically adjusts server max population based on current player count with a configurable cooldown.")]
    public class ElasticPopulation : RustPlugin
    {
        private ConfigData configData;

        class ConfigData
        {
            public int MaxPlayersOffset { get; set; }
            public float CooldownPeriod { get; set; }
        }

        protected override void LoadDefaultConfig()
        {
            Puts("Creating a new configuration file.");
            configData = new ConfigData
            {
                MaxPlayersOffset = 1,
                CooldownPeriod = 10.0f
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
            SetMaxPlayers();
        }

        private void OnPlayerDisconnected(BasePlayer player, string reason)
        {
            timer.Once(configData.CooldownPeriod, SetMaxPlayers);
        }

        private void SetMaxPlayers()
        {
            int currentPlayers = BasePlayer.activePlayerList.Count;
            int newMaxPlayers = currentPlayers + configData.MaxPlayersOffset;

            if (ConVar.Server.maxplayers != newMaxPlayers)
            {
                ConVar.Server.maxplayers = newMaxPlayers;
                Puts($"Max players adjusted to: {newMaxPlayers}");
            }
        }
    }
}
