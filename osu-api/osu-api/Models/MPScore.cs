using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace osu_api.Models
{
    public class MPScore
    {
        [JsonProperty(PropertyName = "slot")]
        public int Slot;
        [JsonProperty(PropertyName = "team")]
        public int Team;
        [JsonProperty(PropertyName = "user_id")]
        public int UserID;
        [JsonProperty(PropertyName = "score")]
        public int Score;
        [JsonProperty(PropertyName = "maxcombo")]
        public int MaxCombo;
        [JsonProperty(PropertyName = "rank")]
        public int Rank; //unused
        [JsonProperty(PropertyName = "count50")]
        public int count50;
        [JsonProperty(PropertyName = "count100")]
        public int count100;
        [JsonProperty(PropertyName = "count300")]
        public int count300;
        [JsonProperty(PropertyName = "countmiss")]
        public int countmiss;
        [JsonProperty(PropertyName = "countgeki")]
        public int countgeki;
        [JsonProperty(PropertyName = "countkatu")]
        public int countkatu;
        [JsonProperty(PropertyName = "perfect")]
        public int perfect;
        [JsonProperty(PropertyName = "pass")]
        public int pass;
    }
}
