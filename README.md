**Description:** Dynamically adjusts the server max population based on current player count, with a configurable cooldown to enhance performance and limit settings.

## Features
- **Dynamic Population Control:** Automatically updates the server's maximum player limit based on the current number of players, ensuring the max players setting is always one step ahead of the current population.
- **Configurable Maximum Population:** Allows setting an absolute maximum population limit that the server will not exceed, regardless of other calculations.
- **Configurable Cooldown:** Includes a cooldown mechanism to prevent the server settings from being updated too frequently, helping to maintain server performance.
- **Console Message Toggle:** Allows server administrators to enable or disable console messages when the max population is adjusted to reduce log clutter.
- **Efficient Timer Management:** Implements a smarter timer mechanism that avoids unnecessary recalculations when multiple players connect or disconnect in quick succession.

## Configuration
The plugin uses a JSON configuration file which is automatically generated if it does not exist. Here are the default settings and descriptions for each configurable option:

```json
{
  "MaxPlayersOffset": 1,
  "CooldownPeriod": 10.0,
  "MaximumPopulation": 200,
  "ConsoleMessagesEnabled": true
}
```
- **MaxPlayersOffset:** The number of player slots to add to the current player count when setting the maximum players (default is 1).
- **CooldownPeriod:** The cooldown period in seconds between adjustments to prevent performance degradation (default is 10 seconds).
- **MaximumPopulation:** The highest number of players that the server can support at any time (default is 200).
- **ConsoleMessagesEnabled:** Whether to log changes to the server's max players in the console (default is true).

## Commands
This plugin operates in the background automatically and does not require any commands to be used by players or administrators.

## Permissions
No permissions are required for this plugin as it is designed for server-side configuration and operation.

## Installation
1. Download the `ElasticPopulation.cs` file from the ElasticPopulation page on uMod.
2. Place the file in your `/oxide/plugins` directory.
3. Use the command `o.load ElasticPopulation` to load the plugin.
4. The plugin will automatically create a default configuration file if one doesn't already exist.

## Usage
After installation, the plugin will function automatically. Server administrators can modify the `MaxPlayersOffset`, `CooldownPeriod`, `MaximumPopulation`, and `ConsoleMessagesEnabled` in the configuration file to tailor the plugin to their server's needs.

## Troubleshooting
If you encounter issues, check the server console for any error messages related to the ElasticPopulation plugin. Ensure that the configuration file is formatted correctly and that you have the latest version of the plugin.