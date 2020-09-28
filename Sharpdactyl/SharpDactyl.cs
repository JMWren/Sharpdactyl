using System.Collections.Generic;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using SharpdactylLib.Enums;
using SharpdactylLib.Exceptions;
using SharpdactylLib.Helpers;
using SharpdactylLib.Models.Client;
using SharpdactylLib.Models.Node;
using SharpdactylLib.Models.User;

namespace SharpdactylLib
{
    /// <summary>
    /// Class representing interactions with the Pterodactyl game panel
    /// </summary>
    public class SharpDactyl
    {
        private const string MissingCredentials = "Hostname and/or apikey is not provided!";
        private readonly WebHelper _web;

        /// <summary>The client api</summary>
        public ClientApi Client{ get; set; }

        /// <summary>The application api</summary>
        public ApplicationApi Application { get; set; }

        /// <summary>
        /// Constructor for a client that interface's with Pterodactyl game panel system.
        /// </summary>
        /// <param name="hostName">the full url of the game panel</param>
        /// <param name="apiKey">the api key</param>
        public SharpDactyl(string hostName, string apiKey)
        {
            _web = new WebHelper(hostName, apiKey);
            Client = new ClientApi(_web);
            Application = new ApplicationApi(_web);
        }

        #region Client Code
        /// <summary>
        /// Represents the client api class
        /// </summary>
        public class ClientApi
        {
            private readonly WebHelper _web;

            /// <summary>
            /// Constructor for a Application api that interface's with Pterodactyl game panel system.
            /// </summary>
            /// <param name="web">The webhelper</param>
            public ClientApi(WebHelper web) => _web = web;

            /// <summary>
            /// Get all servers
            /// </summary>
            /// <returns>the servers</returns>
            /// <exception cref="MissingCredentialsException"></exception>
            ///

            public async Task<List<ServerDatum>> GetServers()
            {

                if (_web == null)
                {
                    throw new MissingCredentialsException(MissingCredentials);
                }
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                var result = await _web.Get("client");
                var model = JsonConvert.DeserializeObject<Server>(result, settings);
                return model.Data.ToList();
            }

            /// <summary>
            /// Get a server by the id
            /// </summary>
            /// <param name="id">the server id</param>
            /// <returns>the server</returns>
            /// <exception cref="MissingCredentialsException"></exception>
            public async Task<ServerDatum> GetServerById(string id)
            {
                if (_web == null)
                {
                    throw new MissingCredentialsException(MissingCredentials);
                }
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                var result = await _web.Get($"client/servers/{id}");
                return JsonConvert.DeserializeObject<ServerDatum>(result, settings);
            }

            /// <summary>
            /// Get the usage of a server
            /// </summary>
            /// <param name="id">the server id</param>
            /// <returns>the server usage</returns>
            /// <exception cref="MissingCredentialsException"></exception>
            public async Task<ServerUtil> GetServerUsage(string id)
            {
                if (_web == null)
                {
                    throw new MissingCredentialsException(MissingCredentials);
                }
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                var result = await _web.Get("client");
                return JsonConvert.DeserializeObject<ServerUtil>(result, settings);
            }

            /// <summary>
            /// Send a power command to a server
            /// </summary>
            /// <param name="serverId">the server id</param>
            /// <param name="signal">the signal</param>
            /// <returns>the result of the command</returns>
            /// <exception cref="MissingCredentialsException"></exception>
            public async Task<bool> SendSignal(string serverId, PowerSettings signal)
            {
                if (_web == null)
                {
                    throw new MissingCredentialsException(MissingCredentials);
                }
                var data = new NameValueCollection { ["signal"] = signal.ToString() };
                var result = await _web.Post($"client/servers/{serverId}/power", data);
                return string.IsNullOrEmpty(result);
            }

            /// <summary>
            /// Send a console command to the server
            /// </summary>
            /// <param name="serverId">the server id</param>
            /// <param name="command">the command to send</param>
            /// <returns>the result of the command</returns>
            /// <exception cref="MissingCredentialsException"></exception>
            public async Task<bool> PostConsoleCommand(string serverId, string command)
            {
                if (_web == null)
                {
                    throw new MissingCredentialsException(MissingCredentials);
                }
                var data = new NameValueCollection { ["command"] = command };
                var result = await _web.Post($"client/servers/{serverId}/command", data);
                return string.IsNullOrEmpty(result);
            }
        }
        #endregion

        #region Application Code
        /// <summary>
        /// Represents the Application api class
        /// </summary>
        public class ApplicationApi
        {
            private readonly WebHelper _web;

            /// <summary>
            /// Constructor for the Application API that interface's with Pterodactyl game panel system.
            /// </summary>
            /// <param name="web">The webhelper</param>
            public ApplicationApi(WebHelper web) => _web = web;

            /// <summary>
            /// Get all users
            /// </summary>
            /// <returns>A list of users</returns>
            /// <exception cref="MissingCredentialsException"></exception>
            public async Task<List<UserDatum>> GetUsers()
            {
                if (_web == null)
                {
                    throw new MissingCredentialsException(MissingCredentials);
                }
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                var result = await _web.Get("application/users");
                var model = JsonConvert.DeserializeObject<User>(result, settings);
                return model.Data.ToList();
            }

            /// <summary>
            /// Get an user by id
            /// </summary>
            /// <param name="id"></param>
            /// <returns>the user</returns>
            /// <exception cref="MissingCredentialsException"></exception>
            public async Task<UserDatum> GetUserByExternalId(string id)
            {
                if (_web == null)
                {
                    throw new MissingCredentialsException(MissingCredentials);
                }
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                var result = await _web.Get($"application/users/external/{id}");
                return JsonConvert.DeserializeObject<UserDatum>(result, settings);
            }

            /// <summary>
            /// Create a user
            /// </summary>
            /// <param name="username">the username</param>
            /// <param name="email">the email address</param>
            /// <param name="first">the firstname</param>
            /// <param name="last">the lastname</param>
            /// <param name="password">the password</param>
            /// <returns>the created user</returns>
            /// <exception cref="MissingCredentialsException"></exception>
            public async Task<UserDatum> CreateUser(string username, string email, string first, string last, string password)
            {
                if (_web == null)
                {
                    throw new MissingCredentialsException(MissingCredentials);
                }
                var data = new NameValueCollection
                {
                    ["username"] = username,
                    ["email"] = email,
                    ["first_name"] = first,
                    ["last_name"] = last,
                    ["password"] = password
                };
                var result = await _web.Post("application/users", data);
                return JsonConvert.DeserializeObject<UserDatum>(result);
            }

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
            /// <exception cref="MissingCredentialsException"></exception>
            public async Task<UserDatum> EditUser(string userId, string username, string email, string first, string last, string password)
            {
                if (_web == null)
                {
                    throw new MissingCredentialsException(MissingCredentials);
                }
                var data = new NameValueCollection
                {
                    ["username"] = username,
                    ["email"] = email,
                    ["first_name"] = first,
                    ["last_name"] = last,
                    ["password"] = password
                };
                var result = await _web.Patch($"application/users/{userId}", data);
                return JsonConvert.DeserializeObject<UserDatum>(result);
            }

            /// <summary>
            /// Delete a user by id
            /// </summary>
            /// <param name="userId">the userid</param>
            /// <returns></returns>
            /// <exception cref="MissingCredentialsException"></exception>
            public async Task DeleteUser(string userId)
            {
                if (_web == null)
                {
                    throw new MissingCredentialsException(MissingCredentials);
                }
                await _web.Delete($"application/users/{userId}");
            }

            /// <summary>
            /// Get all server nodes
            /// </summary>
            /// <returns>A list of nodes</returns>
            /// <exception cref="MissingCredentialsException"></exception>
            public async Task<List<NodeDatum>> GetNodes()
            {
                if (_web == null)
                {
                    throw new MissingCredentialsException(MissingCredentials);
                }
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                var result = await _web.Get("application/nodes");
                var model = JsonConvert.DeserializeObject<Node>(result, settings);
                return model.Data.ToList();
            }

            /// <summary>
            /// Get server node by id
            /// </summary>
            /// <param name="id">the id</param>
            /// <returns>the server node</returns>
            /// <exception cref="MissingCredentialsException"></exception>
            public async Task<NodeDatum> GetNodeById(string id)
            {
                if (_web == null)
                {
                    throw new MissingCredentialsException(MissingCredentials);
                }
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                var result = await _web.Get($"application/nodes/{id}");
                return JsonConvert.DeserializeObject<NodeDatum>(result, settings);
            }

            /// <summary>
            /// Get all servers
            /// </summary>
            /// <returns>A list of servers</returns>
            /// <exception cref="MissingCredentialsException"></exception>
            public async Task<List<ServerDatum>> GetServers()
            {
                if (_web == null)
                {
                    throw new MissingCredentialsException(MissingCredentials);
                }
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                var result = await _web.Get("application/servers");
                var model = JsonConvert.DeserializeObject<Server>(result, settings);
                return model.Data.ToList();
            }

            /// <summary>
            /// Get server by id
            /// </summary>
            /// <param name="id">the server id</param>
            /// <returns>the server</returns>
            /// <exception cref="MissingCredentialsException"></exception>
            public async Task<ServerDatum> GetServerById(string id)
            {
                if (_web == null)
                {
                    throw new MissingCredentialsException(MissingCredentials);
                }
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                var result = await _web.Get($"application/servers/{id}");
                return JsonConvert.DeserializeObject<ServerDatum>(result, settings);
            }

            /// <summary>
            /// Create server
            /// </summary>
            /// <param name="srva">the server details</param>
            /// <returns>the created server</returns>
            /// <exception cref="MissingCredentialsException"></exception>
            public async Task<ServerDatum> CreateServer(ServerDatum srva)
            {
                if (_web == null)
                {
                    throw new MissingCredentialsException(MissingCredentials);
                }
                var data = JsonConvert.SerializeObject(srva.Attributes);
                var result = await _web.PostJSON("application/servers/", data);
                return JsonConvert.DeserializeObject<ServerDatum>(result);
            }

            /// <summary>
            /// Suspend server
            /// </summary>
            /// <param name="id">the server id</param>
            /// <returns></returns>
            /// <exception cref="MissingCredentialsException"></exception>
            public async Task SuspendServerById(string id)
            {
                if (_web == null)
                {
                    throw new MissingCredentialsException(MissingCredentials);
                }
                await _web.Post($"application/servers/{id}/suspend", null);
            }

            /// <summary>
            /// Unsuspend server
            /// </summary>
            /// <param name="id">the server id</param>
            /// <returns></returns>
            /// <exception cref="MissingCredentialsException"></exception>
            public async Task UnSuspendServerById(string id)
            {
                if (_web == null)
                {
                    throw new MissingCredentialsException(MissingCredentials);
                }
                await _web.Post($"application/servers/{id}/unsuspend", null);
            }

            /// <summary>
            /// Reinstall server
            /// </summary>
            /// <param name="id">the server id</param>
            /// <returns></returns>
            /// <exception cref="MissingCredentialsException"></exception>
            public async Task ReinstallServerById(string id)
            {
                if (_web == null)
                {
                    throw new MissingCredentialsException(MissingCredentials);
                }
                await _web.Post($"application/servers/{id}/reinstall", null);
            }

            /// <summary>
            /// Rebuild server
            /// </summary>
            /// <param name="id">the server id</param>
            /// <returns></returns>
            /// <exception cref="MissingCredentialsException"></exception>
            public async Task RebuildServerById(string id)
            {
                if (_web == null)
                {
                    throw new MissingCredentialsException(MissingCredentials);
                }
                await _web.Post($"application/servers/{id}/rebuild", null);
            }

            /// <summary>
            /// Delete server
            /// </summary>
            /// <param name="id">the server</param>
            /// <param name="force">force remove</param>
            /// <returns></returns>
            /// <exception cref="MissingCredentialsException"></exception>
            public async Task DeleteServerById(string id, bool force)
            {
                if (_web == null)
                {
                    throw new MissingCredentialsException(MissingCredentials);
                }
                await _web.Delete(force ? $"application/servers/{id}/force" : $"application/servers/{id}");
            }

            /// <summary>
            /// Delete server
            /// </summary>
            /// <param name="id">the server</param>
            /// <returns></returns>
            /// <exception cref="MissingCredentialsException"></exception>
            public async Task Admin_DeleteServerById(string id)
            {
                await DeleteServerById(id, false).ConfigureAwait(false);
            }
            #endregion

        }

    }
}
