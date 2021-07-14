using Flurl.Http;
using Newtonsoft.Json;
using SharpdactylLib.Exceptions;
using SharpdactylLib.Helpers;
using SharpdactylLib.Models.Application.Locations;
using SharpdactylLib.Models.Application.Nests;
using SharpdactylLib.Models.Application.Nests.Eggs;
using SharpdactylLib.Models.Application.Nodes;
using SharpdactylLib.Models.Application.Nodes.Allocations;
using SharpdactylLib.Models.Application.Servers;
using SharpdactylLib.Models.Application.Servers.Databases;
using SharpdactylLib.Models.Application.Users;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SharpdactylLib
{
    public class SharpdactylApplication
    {
        private const string MissingCredentials = "Hostname and/or apikey is not provided!";
        private readonly WebHelper _web;
        private readonly JsonSerializerSettings settings;

        /// <summary>
        /// Constructor for the Application API that interface's with Pterodactyl game panel system.
        /// </summary>
        /// <param name="web">The webhelper</param>
        public SharpdactylApplication(string hostName, string applicationKey)
        {
            _web = new WebHelper(hostName, applicationKey);
            settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
        }

        #region User Methods
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

            var result = await _web.Get("application/users");
            var model = JsonConvert.DeserializeObject<User>(result, settings);
            return model.Data.ToList();
        }

        /// <summary>
        /// Get a user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The user</returns>
        /// <exception cref="MissingCredentialsException"></exception>
        public async Task<UserDatum> GetUser(long id)
        {
            if (_web == null)
            {
                throw new MissingCredentialsException(MissingCredentials);
            }

            var result = await _web.Get($"application/users/{id}");
            return JsonConvert.DeserializeObject<UserDatum>(result, settings);
        }

        /// <summary>
        /// Get an user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>the user</returns>
        /// <exception cref="MissingCredentialsException"></exception>
        public async Task<UserDatum> GetUser(string externalId)
        {
            if (_web == null)
            {
                throw new MissingCredentialsException(MissingCredentials);
            }

            var result = await _web.Get($"application/users/external/{externalId}");
            return JsonConvert.DeserializeObject<UserDatum>(result, settings);
        }

        /// <summary>
        /// Create a user
        /// </summary>
        /// <param name="username">the username</param>
        /// <param name="email">the email address</param>
        /// <param name="firstName">the firstname</param>
        /// <param name="lastName">the lastname</param>
        /// <param name="password">the password</param>
        /// <returns>the created user</returns>
        /// <exception cref="MissingCredentialsException"></exception>
        public async Task<UserDatum> CreateUser(string email, string username, string firstName, string lastName, string password = "")
        {
            if (_web == null)
            {
                throw new MissingCredentialsException(MissingCredentials);
            }
            var data = new
            {
                email,
                username,
                first_name = firstName,
                last_name = lastName,
                password
            };

            var result = await _web.Post("application/users", data);
            return JsonConvert.DeserializeObject<UserDatum>(result);
        }

        /// <summary>
        /// Edits a user
        /// </summary>
        /// <param name="userId">the userid</param>
        /// <param name="username">the new username</param>
        /// <param name="email">the email address</param>
        /// <param name="first">the firstname</param>
        /// <param name="last">the lastnale</param>
        /// <param name="password">the password</param>
        /// <returns>The edited user</returns>
        /// <exception cref="MissingCredentialsException"></exception>
        public async Task<UserDatum> UpdateUser(long userId, string username, string email,
            string first_name, string last_name, string language = "en", bool root_admin = false, string password = null)
        {
            if (_web == null)
            {
                throw new MissingCredentialsException(MissingCredentials);
            }
            var data = new
            {
                username,
                email,
                first_name,
                last_name,
                language,
                root_admin,
                password
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
        public async Task DeleteUser(long userId)
        {
            if (_web == null)
            {
                throw new MissingCredentialsException(MissingCredentials);
            }
            await _web.Delete($"application/users/{userId}");
        }
        #endregion

        #region Node Methods
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
        public async Task<NodeDatum> GetNode(long id)
        {
            if (_web == null)
            {
                throw new MissingCredentialsException(MissingCredentials);
            }

            var result = await _web.Get($"application/nodes/{id}");
            return JsonConvert.DeserializeObject<NodeDatum>(result, settings);
        }

        /// <summary>
        /// Creates a server node
        /// </summary>
        /// <param name="id">the id</param>
        /// <returns>The server node</returns>
        /// <exception cref="MissingCredentialsException"></exception>
        public async Task<NodeDatum> CreateNode(string name, long locationId, string fqdn, string scheme, int memoryMB,
            int memoryOverallocate, int diskMB, int diskOverallocate, int maxUploadMB, int daemonSFTP, int daemonListen)
        {
            if (_web == null)
            {
                throw new MissingCredentialsException(MissingCredentials);
            }

            var body = new
            {
                name,
                location_id = locationId,
                fqdn,
                scheme,
                memory = memoryMB,
                memory_overallocate = memoryOverallocate,
                disk = diskMB,
                disk_overallocate = diskOverallocate,
                upload_size = maxUploadMB,
                daemon_sftp = daemonSFTP,
                daemon_listen = daemonListen
            };
            var result = await _web.Post("application/nodes", body);
            return JsonConvert.DeserializeObject<NodeDatum>(result, settings);
        }

        /// <summary>
        /// Updates the specified node's settings
        /// </summary>
        /// <param name="nodeId"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="locationId"></param>
        /// <param name="fqdn"></param>
        /// <param name="scheme"></param>
        /// <param name="behindProxy"></param>
        /// <param name="maintenanceMode"></param>
        /// <param name="memoryMB"></param>
        /// <param name="memoryOverallocate"></param>
        /// <param name="diskMB"></param>
        /// <param name="diskOverallocate"></param>
        /// <param name="maxUploadMB"></param>
        /// <param name="daemonSFTP"></param>
        /// <param name="daemonListen"></param>
        /// <returns></returns>
        public async Task<NodeDatum> UpdateNode(long nodeId, string name, string description, long locationId, string fqdn, string scheme,
            bool behindProxy, bool maintenanceMode, int memoryMB, int memoryOverallocate, int diskMB, int diskOverallocate, int maxUploadMB,
            int daemonSFTP, int daemonListen)
        {
            if (_web == null)
            {
                throw new MissingCredentialsException(MissingCredentials);
            }

            var body = new
            {
                name,
                description,
                location_id = locationId,
                fqdn,
                scheme,
                behind_proxy = behindProxy,
                maintenance_mode = maintenanceMode,
                memory = memoryMB,
                memory_overallocate = memoryOverallocate,
                disk = diskMB,
                disk_overallocate = diskOverallocate,
                upload_size = maxUploadMB,
                daemon_sftp = daemonSFTP,
                daemon_listen = daemonListen
            };
            var result = await _web.Patch($"application/nodes/{nodeId}", body);
            return JsonConvert.DeserializeObject<NodeDatum>(result, settings);
        }

        /// <summary>
        /// Deletes the specified node
        /// </summary>
        /// <param name="nodeId"></param>
        public async Task DeleteNode(long nodeId)
        {
            if (_web == null)
            {
                throw new MissingCredentialsException(MissingCredentials);
            }
            await _web.Delete($"application/nodes/{nodeId}");
        }

        /// <summary>
        /// Gets all allocations on the specified node
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns>The list of allocations</returns>
        public async Task<List<AllocationDatum>> GetAllocations(long nodeId)
        {
            if (_web == null)
            {
                throw new MissingCredentialsException(MissingCredentials);
            }
            var result = await _web.Get($"application/nodes/{nodeId}/allocations");
            var model = JsonConvert.DeserializeObject<Allocation>(result, settings);
            return model.Data.ToList();
        }

        /// <summary>
        /// Creates an allocation on a node
        /// </summary>
        /// <param name="nodeId"></param>
        /// <param name="ip"></param>
        /// <param name="ports"></param>
        /// <returns>The created allocation</returns>
        public async Task<AllocationDatum> CreateAllocation(long nodeId, string ip, string[] ports)
        {
            if (_web == null)
            {
                throw new MissingCredentialsException(MissingCredentials);
            }

            var body = new
            { 
                ip,
                ports
            };
            var result = await _web.Post($"application/nodes/{nodeId}/allocations", body);
            return JsonConvert.DeserializeObject<AllocationDatum>(result, settings);
        }

        public async Task DeleteAllocation(long nodeId, long allocationId)
        {
            if (_web == null)
            {
                throw new MissingCredentialsException(MissingCredentials);
            }
            await _web.Delete($"application/nodes/{nodeId}/allocations/{allocationId}");
        }
        #endregion

        #region Location Methods
        /// <summary>
        /// Get all locations on the panel
        /// </summary>
        /// <returns>The list of locations</returns>
        public async Task<List<LocationDatum>> GetLocations()
        {
            if (_web == null)
            {
                throw new MissingCredentialsException(MissingCredentials);
            }

            var result = await _web.Get("application/locations");
            var model = JsonConvert.DeserializeObject<Location>(result, settings);
            return model.Data.ToList();
        }

        /// <summary>
        /// Gets a location by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The location</returns>
        public async Task<LocationDatum> GetLocation(long id)
        {
            if (_web == null)
            {
                throw new MissingCredentialsException(MissingCredentials);
            }
            var result = await _web.Get($"application/locations/{id}");
            return JsonConvert.DeserializeObject<LocationDatum>(result, settings);
        }

        /// <summary>
        /// Creates a new location
        /// </summary>
        /// <param name="identifier"></param>
        /// <param name="description"></param>
        /// <returns>The created location</returns>
        public async Task<LocationDatum> CreateLocation(string identifier, string description)
        {
            if (_web == null)
            {
                throw new MissingCredentialsException(MissingCredentials);
            }

            var body = new
            {
                @short = identifier,
                @long = description
            };
            var result = await _web.Post("application/locations", body);
            return JsonConvert.DeserializeObject<LocationDatum>(result, settings);
        }

        /// <summary>
        /// Updates a specified location
        /// </summary>
        /// <param name="locationId"></param>
        /// <param name="identifier"></param>
        /// <param name="description"></param>
        /// <returns>The updated location</returns>
        public async Task<LocationDatum> UpdateLocation(long locationId, string identifier, string description)
        {
            if (_web == null)
            {
                throw new MissingCredentialsException(MissingCredentials);
            }

            var body = new
            {
                @short = identifier,
                @long = description
            };
            var result = await _web.Patch($"application/locations/{locationId}", body);
            return JsonConvert.DeserializeObject<LocationDatum>(result, settings);
        }

        public async Task DeleteLocation(long locationId)
        {
            if (_web == null)
            {
                throw new MissingCredentialsException(MissingCredentials);
            }
            await _web.Delete($"application/locations/{locationId}");
        }
        #endregion

        #region Server Methods
        /// <summary>
        /// Get all servers
        /// </summary>
        /// <returns>A list of all servers</returns>
        /// <exception cref="MissingCredentialsException"></exception>
        public async Task<List<ServerDatum>> GetServers()
        {
            if (_web == null)
            {
                throw new MissingCredentialsException(MissingCredentials);
            }
            var result = await _web.Get("application/servers");
            var model = JsonConvert.DeserializeObject<Server>(result, settings);
            return model.Data.ToList();
        }

        /// <summary>
        /// Get server by id
        /// </summary>
        /// <param name="id">the server id</param>
        /// <returns>The server</returns>
        /// <exception cref="MissingCredentialsException"></exception>
        public async Task<ServerDatum> GetServer(long id)
        {
            if (_web == null)
            {
                throw new MissingCredentialsException(MissingCredentials);
            }
            var result = await _web.Get($"application/servers/{id}");
            return JsonConvert.DeserializeObject<ServerDatum>(result, settings);
        }

        /// <summary>
        /// Get server by external id
        /// </summary>
        /// <param name="externalId">the external server id</param>
        /// <returns>The server</returns>
        /// <exception cref="MissingCredentialsException"></exception>
        public async Task<ServerDatum> GetServer(string externalId)
        {
            if (_web == null)
            {
                throw new MissingCredentialsException(MissingCredentials);
            }
            var result = await _web.Get($"application/servers/external/{externalId}");
            return JsonConvert.DeserializeObject<ServerDatum>(result, settings);
        }

        /// <summary>
        /// Creates a server with default resource and feature limits. 
        /// Limits may be changed post-creation using the UpdateServerBuild() method.
        /// <para>Will encounter an exception if the IP allocation does not exist, is already in use,
        /// or if all the environment variables defined by the egg are not set.</para>
        /// </summary>
        /// <returns>The created server</returns>
        /// <exception cref="MissingCredentialsException"></exception>
        public async Task<ServerDatum> CreateServer(string name, long ownerId, string dockerImage,
            string startupCommand, int ipAllocationId, int eggId, Dictionary<string, string> environmentVariables)
        {
            if (_web == null)
            {
                throw new MissingCredentialsException(MissingCredentials);
            }

            var body = new
            {
                name,
                user = ownerId,
                egg = eggId,
                docker_image = dockerImage,
                startup = startupCommand,
                environment = environmentVariables,
                limits = new { memory = 1024, swap = 0, disk = 1024, io = 500, cpu = 0 },
                feature_limits = new { databases = 0, backups = 0 },
                allocation = new { @default = ipAllocationId }
            };
            var result = await _web.Post("application/servers", body);
            return JsonConvert.DeserializeObject<ServerDatum>(result, settings);
        }

        /// <summary>
        /// Updates the details of a server
        /// </summary>
        /// <returns>The updated server</returns>
        public async Task<ServerDatum> UpdateServerDetails(long id, string name, long userId, string externalId = null,
            string description = null)
        {
            if (_web == null)
            {
                throw new MissingCredentialsException(MissingCredentials);
            }

            var body = new
            {
                name,
                user = userId,
                external_id = externalId,
                description
            };
            var result = await _web.Patch($"application/servers/{id}/details", body);
            return JsonConvert.DeserializeObject<ServerDatum>(result, settings);
        }

        /// <summary>
        /// Updates the server build
        /// </summary>
        /// <returns>The updated server</returns>
        /// <exception cref="MissingCredentialsException"></exception>
        public async Task<ServerDatum> UpdateServerBuild(long id, int ipAllocationId, int memoryMB = 1024, int swapMB = 0,
            int diskMB = 1024, int ioProportion = 500, int cpuPercent = 0, int? thread = null, int databaseLimit = 0,
            int allocationLimit = 0, int backupLimit = 0)
        {
            if (_web == null)
            {
                throw new MissingCredentialsException(MissingCredentials);
            }

            var body = new
            {
                allocation = ipAllocationId,
                memory = memoryMB,
                swap = swapMB,
                disk = diskMB,
                io = ioProportion,
                cpu = cpuPercent,
                threads = thread,
                feature_limits = new { databases = databaseLimit, allocations = allocationLimit, backups = backupLimit }
            };
            var result = await _web.Patch($"application/servers/{id}/build", body);
            return JsonConvert.DeserializeObject<ServerDatum>(result, settings);
        }

        /// <summary>
        /// Updates the server startup parameters 
        /// </summary>
        /// <returns>The updated server</returns>
        public async Task<ServerDatum> UpdateServerStartup(long id, string startupCommand, string dockerImage,
            long eggId, Dictionary<string, string> environmentVariables, bool skipScripts = false)
        {
            if (_web == null)
            {
                throw new MissingCredentialsException(MissingCredentials);
            }

            var body = new
            {
                startup = startupCommand,
                environment = environmentVariables,
                egg = eggId,
                image = dockerImage,
                skip_scripts = skipScripts
            };
            var result = await _web.Patch($"application/servers/{id}/startup", body);
            return JsonConvert.DeserializeObject<ServerDatum>(result, settings);
        }

        /// <summary>
        /// Suspend server
        /// </summary>
        /// <param name="id">The server id</param>
        /// <exception cref="MissingCredentialsException"></exception>
        public async Task SuspendServer(long id)
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
        /// <exception cref="MissingCredentialsException"></exception>
        public async Task UnSuspendServer(long id)
        {
            if (_web == null)
            {
                throw new MissingCredentialsException(MissingCredentials);
            }
            await _web.Post($"application/servers/{id}/unsuspend", null);
        }

        /// <summary>
        /// Reinstalls a server
        /// </summary>
        /// <param name="id">the server id</param>
        /// <returns></returns>
        /// <exception cref="MissingCredentialsException"></exception>
        public async Task ReinstallServer(long id)
        {
            if (_web == null)
            {
                throw new MissingCredentialsException(MissingCredentials);
            }
            await _web.Post($"application/servers/{id}/reinstall", null);
        }

        /// <summary>
        /// Deletes a server
        /// </summary>
        /// <param name="id">the server</param>
        /// <param name="force">force remove</param>
        /// <exception cref="MissingCredentialsException"></exception>
        public async Task DeleteServer(long id, bool force = false)
        {
            if (_web == null)
            {
                throw new MissingCredentialsException(MissingCredentials);
            }
            await _web.Delete(force ? $"application/servers/{id}/force" : $"application/servers/{id}");
        }

        /// <summary>
        /// Gets all databases belonging to a server
        /// </summary>
        /// <param name="serverId"></param>
        /// <returns>All databases belonging to the server</returns>
        /// <exception cref="MissingCredentialsException"></exception>
        public async Task<List<DatabaseDatum>> GetDatabases(long serverId)
        {
            if (_web == null)
            {
                throw new MissingCredentialsException(MissingCredentials);
            }
            var result = await _web.Get($"application/servers/{serverId}/databases");
            var model = JsonConvert.DeserializeObject<Database>(result, settings);
            return model.Data.ToList();
        }

        /// <summary>
        /// Gets specified database belonging to a server
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="databaseId"></param>
        /// <returns>The database</returns>
        /// <exception cref="MissingCredentialsException"></exception>
        public async Task<DatabaseDatum> GetDatabase(long serverId, long databaseId)
        {
            if (_web == null)
            {
                throw new MissingCredentialsException(MissingCredentials);
            }
            var result = await _web.Get($"application/servers/{serverId}/databases/{databaseId}");
            return JsonConvert.DeserializeObject<DatabaseDatum>(result, settings);
        }

        /// <summary>
        /// Creates a new database for a server
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="name"></param>
        /// <param name="hostId"></param>
        /// <param name="remote"></param>
        /// <returns>The created database</returns>
        /// <exception cref="MissingCredentialsException"></exception>
        public async Task<DatabaseDatum> CreateDatabase(long serverId, string name, long hostId, string remote = "%")
        {
            if (_web == null)
            {
                throw new MissingCredentialsException(MissingCredentials);
            }

            var body = new
            {
                database = name,
                remote,
                host = hostId
            };
            var result = await _web.Post($"application/servers/{serverId}/databases", body);
            return JsonConvert.DeserializeObject<DatabaseDatum>(result, settings);
        }

        /// <summary>
        /// Resets the password of the database
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="databaseId"></param>
        /// <exception cref="MissingCredentialsException"></exception>
        public async Task ResetDatabasePassword(long serverId, long databaseId)
        {
            if (_web == null)
            {
                throw new MissingCredentialsException(MissingCredentials);
            }
            await _web.Post($"application/servers/{serverId}/databases/{databaseId}/reset-password", null);
        }

        /// <summary>
        /// Deletes the specified database
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="databaseId"></param>
        /// <exception cref="MissingCredentialsException"></exception>
        public async Task DeleteDatabase(long serverId, long databaseId)
        {
            if (_web == null)
            {
                throw new MissingCredentialsException(MissingCredentials);
            }
            await _web.Delete($"application/servers/{serverId}/databases/{databaseId}");
        }
        #endregion

        #region Nest Methods
        /// <summary>
        /// Gets a list of all nests 
        /// </summary>
        /// <returns>The list of nests</returns>
        public async Task<List<NestDatum>> GetNests()
        {
            if (_web == null)
            {
                throw new MissingCredentialsException(MissingCredentials);
            }

            var result = await _web.Get("application/nests");
            var model = JsonConvert.DeserializeObject<Nest>(result, settings);
            return model.Data.ToList();
        }

        /// <summary>
        /// Gets a nest by id
        /// </summary>
        /// <param name="nestId"></param>
        /// <returns>The nest</returns>
        public async Task<NestDatum> GetNest(long nestId)
        {
            if (_web == null)
            {
                throw new MissingCredentialsException(MissingCredentials);
            }
            var result = await _web.Get($"application/nests/{nestId}");
            return JsonConvert.DeserializeObject<NestDatum>(result, settings);
        }

        /// <summary>
        /// Gets a list of eggs belonging to a nest
        /// </summary>
        /// <param name="nestId"></param>
        /// <returns>The list of eggs</returns>
        public async Task<List<EggDatum>> GetEggs(long nestId)
        {
            if (_web == null)
            {
                throw new MissingCredentialsException(MissingCredentials);
            }

            var result = await _web.Get($"application/nests/{nestId}/eggs");
            var model = JsonConvert.DeserializeObject<Egg>(result, settings);
            return model.Data.ToList();
        }

        /// <summary>
        /// Gets an egg by id
        /// </summary>
        /// <param name="nestId"></param>
        /// <param name="eggId"></param>
        /// <returns>The egg</returns>
        public async Task<EggDatum> GetEgg(long nestId, long eggId)
        {
            if (_web == null)
            {
                throw new MissingCredentialsException(MissingCredentials);
            }
            var result = await _web.Get($"application/nests/{nestId}/eggs/{eggId}");
            return JsonConvert.DeserializeObject<EggDatum>(result, settings);
        }
        #endregion
    }
}
