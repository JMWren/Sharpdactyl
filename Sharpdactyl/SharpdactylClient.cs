using Newtonsoft.Json;
using SharpdactylLib.Enums;
using SharpdactylLib.Exceptions;
using SharpdactylLib.Helpers;
using SharpdactylLib.Models.Application.Servers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpdactylLib
{
    /// <summary>
    /// Represents the client api class
    /// </summary>
    public class SharpdactylClient
    {
        private const string MissingCredentials = "Hostname and/or apikey is not provided!";
        private readonly WebHelper _web;

        /// <summary>
        /// Constructor for a Client api that interface's with Pterodactyl game panel system.
        /// </summary>
        /// <param name="web">The webhelper</param>
        public SharpdactylClient(string hostname, string clientKey)
        {
            _web = new WebHelper(hostname, clientKey);
        }

        public async Task SendCommand(string identifier, string command)
        {
            var data = new Dictionary<string, string>();
            data.Add("command", command);
            await _web.Post($"client/servers/{identifier}/command", data);
        }

        /// <summary>
        /// Get all servers
        /// </summary>
        /// <returns>the servers</returns>
        /// <exception cref="MissingCredentialsException"></exception>
        ///

        public async Task<List<ApplicationServerContainer>> GetServers()
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
            return JsonConvert.DeserializeObject<List<ApplicationServerContainer>>(result, settings);
        }

        /// <summary>
        /// Get a server by the id
        /// </summary>
        /// <param name="id">the server id</param>
        /// <returns>the server</returns>
        /// <exception cref="MissingCredentialsException"></exception>
        public async Task<ApplicationServerContainer> GetServerById(string id)
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
            return JsonConvert.DeserializeObject<ApplicationServerContainer>(result, settings);
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
        /*public async Task<bool> SendSignal(string serverId, PowerSettings signal)
        {
            if (_web == null)
            {
                throw new MissingCredentialsException(MissingCredentials);
            }
            var data = new NameValueCollection { ["signal"] = signal.ToString() };
            var result = await _web.Post($"client/servers/{serverId}/power", data);
            return string.IsNullOrEmpty(result);
        }*/

        /// <summary>
        /// Send a console command to the server
        /// </summary>
        /// <param name="serverId">the server id</param>
        /// <param name="command">the command to send</param>
        /// <returns>the result of the command</returns>
        /// <exception cref="MissingCredentialsException"></exception>
        /*public async Task<bool> PostConsoleCommand(string serverId, string command)
        {
            if (_web == null)
            {
                throw new MissingCredentialsException(MissingCredentials);
            }
            var data = new NameValueCollection { ["command"] = command };
            var result = await _web.Post($"client/servers/{serverId}/command", data);
            return string.IsNullOrEmpty(result);
        }*/
    }
}
