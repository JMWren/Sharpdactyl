using Newtonsoft.Json;
using System;

namespace SharpdactylLib.Models.Client.Servers.Schedules
{
    /// <summary>
    /// Represents the full results of a task http request
    /// </summary>
    public class TaskContainerResult
    {
        /// <summary>The task request data</summary>
        [JsonProperty("data")]
        public TaskContainer[] Data { get; set; }
    }

    /// <summary>
    /// Represents all the data inside of a task http request
    /// </summary>
    public class TaskContainer
    {
        /// <summary>The task attributes</summary>
        [JsonProperty("attributes")]
        public Task Attributes { get; set; }
    }

    /// <summary>
    /// Represents all the attributes of a task
    /// </summary>
    public class Task
    {
        /// <summary>The task id</summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>The task position in the schedule sequence</summary>
        [JsonProperty("sequence_id")]
        public int SequenceId { get; set; }
        /// <summary>The task action</summary>
        [JsonProperty("action")]
        public string Action { get; set; }
        /// <summary>The action payload</summary>
        [JsonProperty("payload")]
        public string Payload { get; set; }
        /// <summary>The time offset (in seconds)</summary>
        [JsonProperty("time_offset")]
        public int TimeOffset { get; set; }
        /// <summary>Whether the task is queued</summary>
        [JsonProperty("is_queued")]
        public bool IsQueued { get; set; }
        /// <summary>The task creation time</summary>
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
        /// <summary>The task last updated time</summary>
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
