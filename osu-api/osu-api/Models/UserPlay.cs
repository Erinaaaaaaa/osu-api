using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osu_api.Models
{
    public class UserPlay
    {
        [JsonProperty(PropertyName = "score")]
        public int Score;
        [JsonProperty(PropertyName = "username")]
        public string Username;
        [JsonProperty(PropertyName = "maxcombo")]
        public int MaxCombo;
        [JsonProperty(PropertyName = "count300")]
        public int Count300;
        [JsonProperty(PropertyName = "count100")]
        public int Count100;
        [JsonProperty(PropertyName = "count50")]
        public int Count50;
        [JsonProperty(PropertyName = "countmiss")]
        public int CountMiss;
        [JsonProperty(PropertyName = "countkatu")]
        public int CountKatu;
        [JsonProperty(PropertyName = "countgeki")]
        public int CountGeki;
        [JsonProperty(PropertyName = "perfect")]
        public int FullCombo;
        [JsonProperty(PropertyName = "enabled_mods")]
        public int Mods;
        [JsonProperty(PropertyName = "user_id")]
        public int UserID;
        [JsonProperty(PropertyName = "date")]
        public DateTime Date;
        [JsonProperty(PropertyName = "Rank")]
        public string Grade;
    }
}
