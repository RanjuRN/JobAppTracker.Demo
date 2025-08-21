using JobAppTracker.Demo.Constants;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JobAppTracker.Demo.Model
{
    public class JobTracker
    {
        
        public long Id { get; set; }
        public string JobRefID  { get; set; }
        public string JobRole { get; set; }
        public string JobSummary { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public JobType JobType { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ApplicationStatus JobApplicationStatus { get; set; }
    }
}
