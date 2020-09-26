using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sharpdactyl.Models.Client
{
    /// <summary>Represents the hard limits for the server</summary>
    public class Limits
    {
        /// <summary>The memory (MB)</summary>
        [JsonProperty("memory", Required = Required.Always)]
        public int Memory { get; set; }
        /// <summary>The swap (MB)</summary>
        [JsonProperty("swap", Required = Required.Always)]
        public int Swap { get; set; }
        /// <summary>The disk size (MB)</summary>
        [JsonProperty("disk", Required = Required.Always)]
        public int Disk { get; set; }
        /// <summary>the IO</summary>
        [JsonProperty("io", Required = Required.Always)]
        public int Io { get; set; }
        /// <summary>The cpu (%)</summary>
        [JsonProperty("cpu", Required = Required.Always)]
        public int Cpu { get; set; }
    }

    /// <summary>Represents the limits of features</summary>
    public class FeatureLimits
    {
        /// <summary>Max databases</summary>
        [JsonProperty("databases", Required = Required.Always)]
        public int Databases { get; set; }
        /// <summary>Max allocations</summary>
        [JsonProperty("allocations", Required = Required.Always)]
        public int Allocations { get; set; }
    }

    /// <summary>Represents the container</summary>
    public class Container
    {
        /// <summary>The startup command</summary>
        public string Startup_command { get; set; }
        /// <summary>The docker image used</summary>
        public string Image { get; set; }
        /// <summary>The installation status</summary>
        public bool Installed { get; set; }
        /// <summary>Environment settings</summary>
        public Dictionary<string,string> Environment { get; set; }
    }

    /// <summary>Represents the details of the droplet</summary>
    public class Deployment
    {
        /// <summary></summary>
        [JsonProperty("locations", Required = Required.Always)]
        public List<int> Locations { get; set; }
        /// <summary>The dedicated ip</summary>
        [JsonProperty("dedicated_ip", Required = Required.Always)]
        public bool Dedicated_Ip { get; set; }
        /// <summary>The assigned ports</summary>
        [JsonProperty("port_range", Required = Required.Always)]
        public List<string> Port_range {get;set;}
    }
    public class Attributes
    {
        /// <summary>The external id</summary>
        [JsonProperty("external_id")]
        public string External_Id { get; set; }
        /// <summary>The name</summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>The description</summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        /// <summary>The droplet limits</summary>
        [JsonProperty("limits")]
        public Limits Limits { get; set; }
        /// <summary>Skip scripts</summary>
        [JsonProperty("skip_scripts")]
        public bool Skip_Scripts { get; set; }
        /// <summary>The limits of features</summary>
        [JsonProperty("feature_limits")]
        public FeatureLimits Feature_Limits { get; set; }
        /// <summary>The user id of the owner</summary>
        [JsonProperty("user")]
        public int User { get; set; }
        /// <summary>The node id where the droplet is hosted</summary>
        [JsonProperty("node")]
        public int Node { get; set; }
        /// <summary>The allocation id</summary>
        [JsonProperty("allocation")]
        public int Allocation { get; set; }
        /// <summary>The nest id</summary>
        [JsonProperty("nest")]
        public int Nest { get; set; }
        /// <summary>Th egg id</summary>
        [JsonProperty("egg")]
        public int Egg { get; set; }
        /// <summary>The pack id</summary>
        [JsonProperty("pack")]
        public int? Pack { get; set; }
        /// <summary>The docker image</summary>
        [JsonProperty("docker_image")]
        public string Docker_image { get; set; }
        /// <summary>The docker container info</summary>
        [JsonProperty("container")]
        public Container Container { get; set; }
        /// <summary>The starup command</summary>
        [JsonProperty("startup")]
        public string Startup { get; set; }
        /// <summary>The environment settings</summary>
        [JsonProperty("environment")]
        public Dictionary<string, string> Environment { get; set; }
        /// <summary>The info of the deployment</summary>
        [JsonProperty("deploy")]
        public Deployment Deploy { get; set; }
        /// <summary>The start on completion</summary>
        [JsonProperty("start_on_completion")]
        public bool Start_On_Completion { get; set; }
    }
    public class ServerDatum
    {
        /// <summary>Attributes</summary>
        [JsonProperty("attributes", Required = Required.Always)]
        public Attributes Attributes { get; set; }
    }
    public class Server
    {
        /// <summary>All servers</summary>
        public List<ServerDatum> Data { get; set; }
    }
}