using System.Collections.Generic;
using System.Threading.Tasks;
using Sharpdactyl.Enums;
using Sharpdactyl.Models.Client;
using Sharpdactyl.Models.Node;
using Sharpdactyl.Models.User;

namespace Sharpdactyl.Interfaces
{
    /// <summary>
    /// Interface ISharpDactyl
    /// </summary>
    public interface ISharpDactyl
    {
        #region Client Code
        /// <summary>
        /// Get all servers
        /// </summary>
        /// <returns>the servers</returns>
        Task<List<ServerDatum>> GetServers();

        /// <summary>
        /// Get a server by the id
        /// </summary>
        /// <param name="id">the server id</param>
        /// <returns>the server</returns>
        Task<ServerDatum> GetServerById(string id);

        /// <summary>
        /// Get the usage of a server
        /// </summary>
        /// <param name="id">the server id</param>
        /// <returns>the server usage</returns>
        Task<ServerUtil> GetServerUsage(string id);

        /// <summary>
        /// Send a power command to a server
        /// </summary>
        /// <param name="serverId">the server id</param>
        /// <param name="signal">the signal</param>
        /// <returns>the result of the command</returns>
        Task<bool> SendSignal(string serverId, PowerSettings signal);

        /// <summary>
        /// Send a console command to the server
        /// </summary>
        /// <param name="serverId">the server id</param>
        /// <param name="command">the command to send</param>
        /// <returns>the result of the command</returns>
        Task<bool> PostConsoleCommand(string serverId, string command);

        #endregion

        #region User Code (Aka admin Api)

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>A list of users</returns>
        Task<List<UserDatum>> Admin_GetUsers();

        /// <summary>
        /// Get an user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>the user</returns>
        Task<UserDatum> Admin_GetUserByExternalId(string id);

        /// <summary>
        /// Create a user
        /// </summary>
        /// <param name="username">the username</param>
        /// <param name="email">the email address</param>
        /// <param name="first">the firstname</param>
        /// <param name="last">the lastname</param>
        /// <param name="password">the password</param>
        /// <returns>the created user</returns>
        Task<UserDatum> Admin_CreateUser(string username, string email, string first, string last, string password);

        /// <summary>
        /// Edit an user
        /// </summary>
        /// <param name="userId">the userid</param>
        /// <param name="username">the new username</param>
        /// <param name="email">the email address</param>
        /// <param name="first">the firstname</param>
        /// <param name="last">the lastnale</param>
        /// <param name="password">the password</param>
        /// <returns>The edited user</returns>
        Task<UserDatum> Admin_EditUser(string userId, string username, string email, string first, string last, string password);

        /// <summary>
        /// Delete a user by id
        /// </summary>
        /// <param name="userId">the userid</param>
        /// <returns></returns>
        Task Admin_DeleteUser(string userId);

        /// <summary>
        /// Get all server nodes
        /// </summary>
        /// <returns>A list of nodes</returns>
        Task<List<NodeDatum>> Admin_GetNodes();

        /// <summary>
        /// Get server node by id
        /// </summary>
        /// <param name="id">the id</param>
        /// <returns>the server node</returns>
        Task<NodeDatum> Admin_GetNodeById(string id);

        /// <summary>
        /// Get all servers
        /// </summary>
        /// <returns>A list of servers</returns>
        Task<List<ServerDatum>> Admin_GetServers();

        /// <summary>
        /// Get server by id
        /// </summary>
        /// <param name="id">the server id</param>
        /// <returns>the server</returns>
        Task<ServerDatum> Admin_GetServerById(string id);

        /// <summary>
        /// Create server
        /// </summary>
        /// <param name="srva">the server details</param>
        /// <returns>the created server</returns>
        Task<ServerDatum> Admin_CreateServer(ServerDatum srva);

        /// <summary>
        /// Suspend server
        /// </summary>
        /// <param name="id">the server id</param>
        /// <returns></returns>
        Task Admin_SuspendServerById(string id);

        /// <summary>
        /// Unsuspend server
        /// </summary>
        /// <param name="id">the server id</param>
        /// <returns></returns>
        Task Admin_UnSuspendServerById(string id);

        /// <summary>
        /// Reinstall server
        /// </summary>
        /// <param name="id">the server id</param>
        /// <returns></returns>
        Task Admin_ReinstallServerById(string id);

        /// <summary>
        /// Rebuild server
        /// </summary>
        /// <param name="id">the server id</param>
        /// <returns></returns>
        Task Admin_RebuildServerById(string id);


        /// <summary>
        /// Delete server
        /// </summary>
        /// <param name="id">the server</param>
        /// <param name="force">force remove</param>
        /// <returns></returns>
        Task Admin_DeleteServerById(string id, bool force = false);

        #endregion
    }
}
