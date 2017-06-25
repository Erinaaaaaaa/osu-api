using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OtakuOverclocks.Utils.Models
{
    public class MPMetadata
    {
        [JsonProperty(PropertyName = "match_id")]
        public int MatchID;
        [JsonProperty(PropertyName = "name")]
        public string MatchName;
        [JsonProperty(PropertyName = "start_time")]
        public DateTime StartTime;
        [JsonProperty(PropertyName = "end_time")]
        public DateTime? EndTime;
    }
}
