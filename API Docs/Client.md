## sharpdactyl Methods

All methods are async, if you don't want to use async, add a `.Result` behind the method.

### Get sharpdactyl Servers
`PCient.GetServers();`
Returns
`List<ServerDatum>`
Example
```csharp
Sharpdactyl sharpdactyl = new Sharpdactyl(hostName, meowmeowmeow);
var result = await sharpdactyl.GetServers();
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
`Sharpdactyl.GetServerById(string id);`
Returns
`ServerDatum`
Example
```csharp
Sharpdactyl sharpdactyl = new Sharpdactyl(hostName, meowmeowmeow);
ServerDatum srv = await sharpdactyl.GetServerById("32e74e55");
Console.WriteLine(srv.Attributes.Name + @ + srv.Attributes.Identifer);
```
Output
```bash
Server #1@32e74e55
```
### Get Server Usage
`Sharpdactyl.GetServerUsage(string id);`
Returns
`ServerUtil`
Example
```csharp
Sharpdactyl sharpdactyl = new Sharpdactyl(hostName, meowmeowmeow);
ServerDatum srv = await sharpdactyl.GetServerById("32e74e55");
ServerUtil srvU = await sharpdactyl.GetServerUsage(srv.Attributes.Identifer);
Console.WriteLine(srvU.Attributes.Memory.Current +  MB Usage);
```
Output
```bash
2048 MB Usage
```
### Sending singals to servers
`Sharpdactyl.SendSignal(string ServerId, PowerSettings signal);`
Returns
`bool`
Example
```csharp
Sharpdactyl sharpdactyl = new Sharpdactyl(hostName, meowmeowmeow);
var result = await sharpdactyl.SendSignal("32e74e55", PowerSettings.start);
Console.WriteLine(result ? "Signal Sent!" : "Failed to send!");
```
### Post a CMD Command
`Sharpdactyl.PostCMDCommand(string ServerId, string command);`
Returns
`bool`
```csharp
Sharpdactyl sharpdactyl = new Sharpdactyl(hostName, meowmeowmeow);
var result = await sharpdactyl.PostCMDCommand("32e74e55", "say Hello!");
Console.WriteLine(result ? "Command Sent!" : "Command Sent!");
```
