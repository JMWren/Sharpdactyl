## Client Methods

All methods are async, if you don't want to use async, add a `.Result` behind the method.

### Get Client Servers
`PCient.GetServers();`
Returns
`List<ServerDatum>`
Example
```csharp
PClient client = new PClient(hostName, meowmeowmeow);
var result = await client.GetServers();
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
`PClient.GetServerById(string id);`
Returns
`ServerDatum`
Example
```csharp
PClient client = new PClient(hostName, meowmeowmeow);
ServerDatum srv = await client.GetServerById("32e74e55");
Console.WriteLine(srv.Attributes.Name + @ + srv.Attributes.Identifer);
```
Output
```bash
Server #1@32e74e55
```
### Get Server Usage
`PClient.GetServerUsage(string id);`
Returns
`ServerUtil`
Example
```csharp
PClient client = new PClient(hostName, meowmeowmeow);
ServerDatum srv = await client.GetServerById("32e74e55");
ServerUtil srvU = await client.GetServerUsage(srv.Attributes.Identifer);
Console.WriteLine(srvU.Attributes.Memory.Current +  MB Usage);
```
Output
```bash
2048 MB Usage
```
### Sending singals to servers
`PClient.SendSignal(string ServerId, PowerSettings signal);`
Returns
`bool`
Example
```csharp
PClient client = new PClient(hostName, meowmeowmeow);
var result = await client.SendSignal("32e74e55", PowerSettings.start);
Console.WriteLine(result ? "Signal Sent!" : "Failed to send!");
```
### Post a CMD Command
`PClient.PostCMDCommand(string ServerId, string command);`
Returns
`bool`
```csharp
PClient client = new PClient(hostName, meowmeowmeow);
var result = await client.PostCMDCommand("32e74e55", "say Hello!");
Console.WriteLine(result ? "Command Sent!" : "Command Sent!");
```
