# ElasticPopulation Plugin Documentation

**Description:** Rust server plugin that dynamically adjusts the server max population to always be the current player count plus a configurable offset, with a cooldown feature to enhance performance.

## Features
- **Dynamic Population Control:** Automatically updates the server's maximum player limit based on the current number of players, ensuring the max players setting is always one step ahead of the current population.
- **Configurable Cooldown:** Includes a cooldown mechanism to prevent the server settings from being updated too frequently, helping to maintain server performance.
- **Configurable Player Offset:** Allows server administrators to define how many extra slots are added to the current player count when setting the max players.
- **Logging Enhancements:** Improved logging to provide details on when the max players setting is adjusted.

## Configuration
The plugin uses a JSON configuration file which is automatically generated if it does not exist. Here are the default settings and descriptions for each configurable option:

```json
{
  "MaxPlayersOffset": 1,
  "CooldownPeriod": 10.0
}
```
- **MaxPlayersOffset:** The number of player slots to add to the current player count when setting the maximum players (default is 1).
- **CooldownPeriod:** The cooldown period in seconds between adjustments to prevent performance degradation (default is 10 seconds).

## Commands
This plugin operates in the background automatically and does not require any commands to be used by players or administrators.

## Permissions
No permissions are required for this plugin as it is designed for server-side configuration and operation.

## Installation
1. Download the `ElasticPopulation.cs` file from the ElasticPopulation page on uMod.
2. Place the file in your `RustServer/oxide/plugins` directory.
3. Restart your server or use the command `oxide.reload ElasticPopulation` to load the plugin.
4. The plugin will automatically create a default configuration file if one doesn't already exist.

## Usage
After installation, the plugin will function automatically. Server administrators can modify the `MaxPlayersOffset` and `CooldownPeriod` in the configuration file to suit their server's needs.

## Troubleshooting
If you encounter issues, check the server console for any error messages related to the ElasticPopulation plugin. Ensure that the configuration file is formatted correctly and that you have the latest version of the plugin.

## Support
For support, questions, or to provide feedback, please visit the ElasticPopulation plugin page on uMod. You can also contribute to improving the plugin by participating in discussions or submitting pull requests with enhancements.
