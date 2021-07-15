using Newtonsoft.Json;
using System;

namespace SharpdactylLib.Models.Client.Servers.Schedules
{
    /// <summary>
    /// Represents the full results of a schedule http request
    /// </summary>
    public class ScheduleContainerResult
    {
        /// <summary>The schedule request data</summary>
        [JsonProperty("data")]
        public ScheduleContainer[] Data { get; set; }
    }

    /// <summary>
    /// Represents the full data of a schedule http request
    /// </summary>
    public class ScheduleContainer
    {
        /// <summary>The schedule attributes</summary>
        [JsonProperty("attributes")]
        public Schedule Attributes { get; set; }
    }

    /// <summary>
    /// Represents the attributes of a schedule
    /// </summary>
    public class Schedule
    {
        /// <summary>The schedule id</summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>The schedule name</summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>The schedule cron object</summary>
        [JsonProperty("cron")]
        public Cron Cron { get; set; }
        /// <summary>Whether the schedule is active</summary>
        [JsonProperty("is_active")]
        public bool IsActive { get; set; }
        /// <summary>Whether the schedule is currently processing</summary>
        [JsonProperty("is_processing")]
        public bool IsProcessing { get; set; }
        /// <summary>Last run time of schedule</summary>
        [JsonProperty("last_run_at")]
        public DateTimeOffset LastRunAt { get; set; }
        /// <summary>Next run time of schedule</summary>
        [JsonProperty("next_run_at")]
        public DateTimeOffset NextRunAt { get; set; }
        /// <summary>Creation time of schedule</summary>
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
        /// <summary>Last updated time of schedule</summary>
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
        /// <summary>The schedule relationships</summary>
        [JsonProperty("relationships")]
        public Relationships Relationships { get; set; }
    }

    /// <summary>
    /// Represents the cron information from a schedule
    /// </summary>
    public class Cron
    {
        /// <summary></summary>
        [JsonProperty("day_of_week")]
        public string DayOfWeek { get; set; }
        /// <summary></summary>
        [JsonProperty("day_of_month")]
        public string DayOfMonth { get; set; }
        /// <summary></summary>
        [JsonProperty("hour")]
        public string Hour { get; set; }
        /// <summary></summary>
        [JsonProperty("minute")]
        public string Minute { get; set; }
    }

    /// <summary>
    /// Represents all of the relationships for the schedule
    /// </summary>
    public class Relationships
    {
        /// <summary>Represents all of the tasks for a schedule</summary>
        [JsonProperty("tasks")]
        public TaskContainerResult Tasks { get; set; }
    }
}
