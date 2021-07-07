using System.Collections.Generic;

namespace SharpdactylLib.Models.Server
{
    /// <summary>Represents the memory</summary>
    public class Memory
    {
        /// <summary>Used memory (MB)</summary>
        public int Current { get; set; }
        /// <summary>Max memory (MB)</summary>
        public int Limit { get; set; }
    }

    /// <summary>Represents the cpu</summary>
    public class Cpu
    {
        /// <summary>Used processor (%)</summary>
        public double Current { get; set; }
        /// <summary>List of cores</summary>
        public List<double> Cores { get; set; }
        /// <summary>Max processor (%)</summary>
        public int Limit { get; set; }
    }

    /// <summary>Represents the storage</summary>
    public class Disk
    {
        /// <summary>Used storage (MB)</summary>
        public int Current { get; set; }
        /// <summary>Max storage (MB)</summary>
        public int Limit { get; set; }
    }

    /// <summary>Represents the droplet info</summary>
    public class UAttributes
    {
        /// <summary>The droplet state</summary>
        public string State { get; set; }
        /// <summary>The droplet memory</summary>
        public Memory Memory { get; set; }
        /// <summary>The droplet cpu</summary>
        public Cpu Cpu { get; set; }
        /// <summary>The droplet disk</summary>
        public Disk Disk { get; set; }
    }

    public class ServerUtil
    {
        /// <summary>Droplet attributes</summary>
        public UAttributes Attributes { get; set; }
    }
}
