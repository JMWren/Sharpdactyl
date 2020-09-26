# Application/Adminstration API

All methods are async, if you don't want to use async, add a `.Result` behind the method.

## Methods
### Get Users
`Sharpdactyl.Admin_GetUsers();`
Returns
`List<UserDatum>`
Example:
```csharp
Sharpdactyl sharpdactyl = new Sharpdactyl(hostName, meowmeowmeow);
var result = await sharpdactyl.Admin_GetUsers():
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
`Sharpdactyl.Admin_GetUserByExternalId(string id);`
Returns:
`UserDatum`
Example:
```csharp
Sharpdactyl sharpdactyl = new Sharpdactyl(hostName, meowmeowmeow);
var result = await sharpdactyl.Admin_GetUserByExternalId("1");
Console.WriteLine(result.Attributes.FirstName);
```
Output
```bash
John
```
### Create User
`Sharpdactyl.Admin_CreateUser(string username, string email, string first, string last, string password);`
Returns:
`UserDatum`
Example:
```csharp
Sharpdactyl sharpdactyl = new Sharpdactyl(hostName, meowmeowmeow);
UserDatum usr = await sharpdactyl.Admin_CreateUser("JohnNumber2","john@yahooi.com", "John2", "Kol", "VerySecurePassword!");
Console.WriteLine(usr.Attributes.FirstName);
```
Output
```bash
John2
```
### Edit User
`Sharpdactyl.Admin_EditUser(string userId, string username, string email, string first, string last, string password);`
Returns:
`UserDatum`
Example:
```csharp
Sharpdactyl sharpdactyl = new Sharpdactyl(hostName, meowmeowmeow);
UserDatum usr = await sharpdactyl.Admin_EditUser("2", "JohnNumber2","john@yahooi.com", "John3", "Kol", "VerySecurePassword!");
Console.WriteLine(usr.Attributes.FirstName);
```
Output
```bash
John3
```
### Delete User
`Sharpdactyl.Admin_DeleteUser(string userId);`
Example:
```csharp
Sharpdactyl sharpdactyl = new Sharpdactyl(hostName, meowmeowmeow);
await sharpdactyl.Admin_DeleteUser("2");
```
### Get Nodes
`Sharpdactyl.Admin_GetNodes();`
Returns:
`List<NodeDatum>`
Example:
```csharp
Sharpdactyl sharpdactyl = new Sharpdactyl(hostName, meowmeowmeow);
List<NodeDatum> nodes = await sharpdactyl.Admin_GetNodes();
```
### Get Node by ID
`Sharpdactyl.Admin_GetNodeById(string id);`
Returns:
`NodeDatum`
Example:
```csharp
Sharpdactyl sharpdactyl = new Sharpdactyl(hostName, meowmeowmeow);
NodeDatum node = await sharpdactyl.Admin_GetNodeById("1");
Console.WriteLine(node.Attributes.Name);
```
Output:
```bash
US-1
```
### Get all servers
`Sharpdactyl.Admin_GetServers();`
Returns:
`List<ServerDatum>`
Example
```csharp
Sharpdactyl sharpdactyl = new Sharpdactyl(hostName, meowmeowmeow);
var result = await sharpdactyl.Admin_GetServers();
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
`Sharpdactyl.Admin_GetServerById(string id);`
`Sharpdactyl.Admin_GetServerByExternalId(string id);`
Returns:
`ServerDatum`
Example:
```csharp
Sharpdactyl sharpdactyl = new Sharpdactyl(hostName, meowmeowmeow);
ServerDatum srv = await sharpdactyl.Admin_GetServerById("32e74e55");
Console.WriteLine(srv.Attributes.Name + @ + srv.Attributes.Identifer);
```
Output
```bash
Server #1@32e74e55
```
### Create a server
`Sharpdactyl.Admin_CreateServer(ServerDatum srv)`
Example:
```csharp
Sharpdactyl sharpdactyl = new Sharpdactyl(hostName, meowmeowmeow);
ServerDatum srva = new ServerDatum();
srva.Attributes.Description = "A new server!";
srva.Attributes.feature_limits = new FeatureLimits() { Allocations = 0, Databases = 0 };
srva.Attributes.Limits = new Limits() { Cpu = 200, Disk = 2000, Io = 56, Memory = 2048 };
srva.Attributes.Name = "New Server!";
await sharpdactyl.Admin_CreateServer(srva);
```
### Ban, Reinstall, Rebuild, Unban, and delete servers
`Sharpdactyl.Admin_BanServerById(string id);`
`Sharpdactyl.Admin_UnBanServerById(string id);`
`Sharpdactyl.Admin_ReinstallServerById(string id);`
`Sharpdactyl.Admin_RebuildServerById(string id);`
`Sharpdactyl.Admin_DeleteServerById(string id, bool force = false);`