## sharpdactyl Methods

All methods are async, if you don't want to use async, add a `.Result` behind the method.

### Get Pterodactyl Servers
`SharpDactyl.Client.GetServers();`
Returns
`List<ServerDatum>`
Example
```csharp
SharpdactylLib.Sharpdactyl sharpdactyl = new SharpdactylLib.Sharpdactyl(hostName, meowmeowmeow);
var result = await sharpdactyl.Client.GetServers();
foreach (ServerDatum srv in result)
{
    Console.WriteLine(srv.Attributes.Name + @ + srv.Attributes.Identifer);
}
```
Output
```bash
Server #1@32e74e55
```
### Get server by ID
`Sharpdactyl.Client.GetServerById(string id);`
Returns
`ServerDatum`
Example
```csharp
SharpdactylLib.Sharpdactyl sharpdactyl = new SharpdactylLib.Sharpdactyl(hostName, meowmeowmeow);
ServerDatum srv = await sharpdactyl.Client.GetServerById("32e74e55");
Console.WriteLine(srv.Attributes.Name + @ + srv.Attributes.Identifer);
```
Output
```bash
Server #1@32e74e55
```
### Get Server Usage
`Sharpdactyl.Client.GetServerUsage(string id);`
Returns
`ServerUtil`
Example
```csharp
SharpdactylLib.Sharpdactyl sharpdactyl = new SharpdactylLib.Sharpdactyl(hostName, meowmeowmeow);
ServerDatum srv = await sharpdactyl.Client.GetServerById("32e74e55");
ServerUtil srvU = await sharpdactyl.Client.GetServerUsage(srv.Attributes.Identifer);
Console.WriteLine(srvU.Attributes.Memory.Current +  MB Usage);
```
Output
```bash
2048 MB Usage
```
### Sending singals to servers
`Sharpdactyl.Client.SendSignal(string ServerId, PowerSettings signal);`
Returns
`bool`
Example
```csharp
SharpdactylLib.Sharpdactyl sharpdactyl = new SharpdactylLib.Sharpdactyl(hostName, meowmeowmeow);
var result = await sharpdactyl.Client.SendSignal("32e74e55", PowerSettings.start);
Console.WriteLine(result ? "Signal Sent!" : "Failed to send!");
```
### Post a CMD Command
`Sharpdactyl.Client.PostCMDCommand(string ServerId, string command);`
Returns
`bool`
```csharp
SharpdactylLib.Sharpdactyl sharpdactyl = new SharpdactylLib.Sharpdactyl(hostName, meowmeowmeow);
var result = await sharpdactyl.Client.PostCMDCommand("32e74e55", "say Hello!");
Console.WriteLine(result ? "Command Sent!" : "Command Sent!");
```
