# Application/Adminstration API

All methods are async, if you don't want to use async, add a `.Result` behind the method.

## Methods
### Get Users
`PClient.Admin_GetUsers();`
Returns
`List<UserDatum>`
Example:
```csharp
PClient client = new PClient(hostName, meowmeowmeow);
var result = await client.Admin_GetUsers():
foreach (ServerDatum usr in result)
{
    Console.WriteLine(usr.Attributes.FirstName);
}
```
Output
```
John
```
### Get user by ID
`PClient.Admin_GetUserByExternalId(string id);`
Returns:
`UserDatum`
Example:
```csharp
PClient client = new PClient(hostName, meowmeowmeow);
var result = await client.Admin_GetUserByExternalId("1");
Console.WriteLine(result.Attributes.FirstName);
```
Output
```
John
```
### Create User
`PClient.Admin_CreateUser(string username, string email, string first, string last, string password);`
Returns:
`UserDatum`
Example:
```csharp
PClient client = new PClient(hostName, meowmeowmeow);
UserDatum usr = await client.Admin_CreateUser("JohnNumber2","john@yahooi.com", "John2", "Kol", "VerySecurePassword!");
Console.WriteLine(usr.Attributes.FirstName);
```
Output
```
John2
```
### Edit User
`PClient.Admin_EditUser(string userId, string username, string email, string first, string last, string password);`
Returns:
`UserDatum`
Example:
```csharp
PClient client = new PClient(hostName, meowmeowmeow);
UserDatum usr = await client.Admin_EditUser("2", "JohnNumber2","john@yahooi.com", "John3", "Kol", "VerySecurePassword!");
Console.WriteLine(usr.Attributes.FirstName);
```
Output
```
John3
```
### Delete User
`PClient.Admin_DeleteUser(string userId);`
Example:
```csharp
PClient client = new PClient(hostName, meowmeowmeow);
await client.Admin_DeleteUser("2");
```
### Get Nodes
`PClient.Admin_GetNodes();`
Returns:
`List<NodeDatum>`
Example:
```csharp
PClient client = new PClient(hostName, meowmeowmeow);
List<NodeDatum> nodes = await client.Admin_GetNodes();
```
### Get Node by ID
`PClient.Admin_GetNodeById(string id);`
Returns:
`NodeDatum`
Example:
```csharp
PClient client = new PClient(hostName, meowmeowmeow);
NodeDatum node = await client.Admin_GetNodeById("1");
Console.WriteLine(node.Attributes.Name);
```
Output:
```
US-1
```
### Get all servers
`PClient.Admin_GetServers();`
Returns:
`List<ServerDatum>`
Example
```csharp
PClient client = new PClient(hostName, meowmeowmeow);
var result = await client.Admin_GetServers();
foreach (ServerDatum srv in result)
{
    Console.WriteLine(srv.Attributes.Name + @ + srv.Attributes.Identifer);
}
```
Output
```
Server #1@32e74e55
Private admin server@e342b218
```
### Get server by id
`PClient.Admin_GetServerById(string id);`
`PClient.Admin_GetServerByExternalId(string id);`
Returns:
`ServerDatum`
Example:
```csharp
PClient client = new PClient(hostName, meowmeowmeow);
ServerDatum srv = await client.Admin_GetServerById("32e74e55");
Console.WriteLine(srv.Attributes.Name + @ + srv.Attributes.Identifer);
```
Output
```
Server #1@32e74e55
```
### Create a server
`PClient.Admin_CreateServer(ServerDatum srv)`
Example:
```csharp
PClient client = new PClient(hostName, meowmeowmeow);
ServerDatum srva = new ServerDatum();
srva.Attributes.Description = "A new server!";
srva.Attributes.feature_limits = new FeatureLimits() { Allocations = 0, Databases = 0 };
srva.Attributes.Limits = new Limits() { Cpu = 200, Disk = 2000, Io = 56, Memory = 2048 };
srva.Attributes.Name = "New Server!";
await client.Admin_CreateServer(srva);
```
### Ban, Reinstall, Rebuild, Unban, and delete servers
`PClient.Admin_BanServerById(string id);`
`PClient.Admin_UnBanServerById(string id);`
`PClient.Admin_ReinstallServerById(string id);`
`PClient.Admin_RebuildServerById(string id);`
`PClient.Admin_DeleteServerById(string id, bool force = false);`