using Newtonsoft.Json;
using SharpdactylLib.Exceptions;
using SharpdactylLib.Helpers;
using SharpdactylLib.Models.Application.Nodes;
using SharpdactylLib.Models.Application.Servers;
using SharpdactylLib.Models.Application.Users;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

namespace SharpdactylLib
{
    public class SharpdactylApplication
    {
        private const string MissingCredentials = "Hostname and/or apikey is not provided!";
        private readonly WebHelper _web;

        /// <summary>
        /// Constructor for the Application API that interface's with Pterodactyl game panel system.
        /// </summary>
        /// <param name="web">The webhelper</param>
        public SharpdactylApplication(string hostName, string applicationKey)
        {
            _web = new WebHelper(hostName, applicationKey);
        }

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
        public async Task<UserDatum> GetUserById(long id)
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
            var result = await _web.Get($"application/users/{id}");
            return JsonConvert.DeserializeObject<UserDatum>(result, settings);
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
    }
}
