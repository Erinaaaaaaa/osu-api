using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace osu_api.Models
{
    public class Score
    {
        [JsonProperty(PropertyName = "score")]
        public int Points;
        [JsonProperty(PropertyName = "username")]
        public string Username;
        [JsonProperty(PropertyName = "count300")]
        public int Count300;
        [JsonProperty(PropertyName = "count100")]
        public int Count100;
        [JsonProperty(PropertyName = "count50")]
        public int Count50;
        [JsonProperty(PropertyName = "countmiss")]
        public int CountMiss;
        [JsonProperty(PropertyName = "maxcombo")]
        public int MaxCombo;
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
        [JsonProperty(PropertyName = "pp")]
        public float PPValue; // they say it's float ¯\_(ツ)_/¯
    }
}
