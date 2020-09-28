# Application/Adminstration API

All methods are async, if you don't want to use async, add a `.Result` behind the method.

## Methods
### Get Users
`Sharpdactyl.Application.GetUsers();`
Returns
`List<UserDatum>`
Example:
```csharp
SharpdactylLib.Sharpdactyl sharpdactyl = new SharpdactylLib.Sharpdactyl(hostName, meowmeowmeow);
var result = await sharpdactyl.Application.GetUsers():
foreach (ServerDatum usr in result)
{
    Console.WriteLine(usr.Attributes.FirstName);
}
```
Output
```bash
John
```
### Get user by ID
`Sharpdactyl.Application.GetUserByExternalId(string id);`
Returns:
`UserDatum`
Example:
```csharp
SharpdactylLib.Sharpdactyl sharpdactyl = new SharpdactylLib.Sharpdactyl(hostName, meowmeowmeow);
var result = await sharpdactyl.Application.GetUserByExternalId("1");
Console.WriteLine(result.Attributes.FirstName);
```
Output
```bash
John
```
### Create User
`Sharpdactyl.Application.CreateUser(string username, string email, string first, string last, string password);`
Returns:
`UserDatum`
Example:
```csharp
SharpdactylLib.Sharpdactyl sharpdactyl = new SharpdactylLib.Sharpdactyl(hostName, meowmeowmeow);
UserDatum usr = await sharpdactyl.Application.CreateUser("JohnNumber2","john@yahooi.com", "John2", "Kol", "VerySecurePassword!");
Console.WriteLine(usr.Attributes.FirstName);
```
Output
```bash
John2
```
### Edit User
`Sharpdactyl.Application.EditUser(string userId, string username, string email, string first, string last, string password);`
Returns:
`UserDatum`
Example:
```csharp
SharpdactylLib.Sharpdactyl sharpdactyl = new SharpdactylLib.Sharpdactyl(hostName, meowmeowmeow);
UserDatum usr = await sharpdactyl.Application.EditUser("2", "JohnNumber2","john@yahooi.com", "John3", "Kol", "VerySecurePassword!");
Console.WriteLine(usr.Attributes.FirstName);
```
Output
```bash
John3
```
### Delete User
`Sharpdactyl.Application.DeleteUser(string userId);`
Example:
```csharp
SharpdactylLib.Sharpdactyl sharpdactyl = new SharpdactylLib.Sharpdactyl(hostName, meowmeowmeow);
await sharpdactyl.Application.DeleteUser("2");
```
### Get Nodes
`Sharpdactyl.Application.GetNodes();`
Returns:
`List<NodeDatum>`
Example:
```csharp
SharpdactylLib.Sharpdactyl sharpdactyl = new SharpdactylLib.Sharpdactyl(hostName, meowmeowmeow);
List<NodeDatum> nodes = await sharpdactyl.Application.GetNodes();
```
### Get Node by ID
`Sharpdactyl.Application.GetNodeById(string id);`
Returns:
`NodeDatum`
Example:
```csharp
SharpdactylLib.Sharpdactyl sharpdactyl = new SharpdactylLib.Sharpdactyl(hostName, meowmeowmeow);
NodeDatum node = await sharpdactyl.Application.GetNodeById("1");
Console.WriteLine(node.Attributes.Name);
```
Output:
```bash
US-1
```
### Get all servers
`Sharpdactyl.Application.GetServers();`
Returns:
`List<ServerDatum>`
Example
```csharp
SharpdactylLib.Sharpdactyl sharpdactyl = new SharpdactylLib.Sharpdactyl(hostName, meowmeowmeow);
var result = await sharpdactyl.Application.GetServers();
foreach (ServerDatum srv in result)
{
    Console.WriteLine(srv.Attributes.Name + @ + srv.Attributes.Identifer);
}
```
Output
```bash
Server #1@32e74e55
Private admin server@e342b218
```
### Get server by id
`Sharpdactyl.Application.GetServerById(string id);`
Returns:
`ServerDatum`
Example:
```csharp
SharpdactylLib.Sharpdactyl sharpdactyl = new SharpdactylLib.Sharpdactyl(hostName, meowmeowmeow);
ServerDatum srv = await sharpdactyl.Application.GetServerById("32e74e55");
Console.WriteLine(srv.Attributes.Name + @ + srv.Attributes.Identifer);
```
Output
```bash
Server #1@32e74e55
```
### Create a server
`Sharpdactyl.Application.CreateServer(ServerDatum srv)`
Example:
```csharp
SharpdactylLib.Sharpdactyl sharpdactyl = new SharpdactylLib.Sharpdactyl(hostName, meowmeowmeow);
ServerDatum srva = new ServerDatum();
srva.Attributes.Description = "A new server!";
srva.Attributes.feature_limits = new FeatureLimits() { Allocations = 0, Databases = 0 };
srva.Attributes.Limits = new Limits() { Cpu = 200, Disk = 2000, Io = 56, Memory = 2048 };
srva.Attributes.Name = "New Server!";
await sharpdactyl.Application.CreateServer(srva);
```
### Ban, Reinstall, Rebuild, Unban, and delete servers
`Sharpdactyl.Application.BanServerById(string id);`
`Sharpdactyl.Application.UnBanServerById(string id);`
`Sharpdactyl.Application.ReinstallServerById(string id);`
`Sharpdactyl.Application.RebuildServerById(string id);`
`Sharpdactyl.Application.DeleteServerById(string id, bool force = false);`