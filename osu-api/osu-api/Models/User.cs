using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OtakuOverclocks.Utils.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class User
    {
        [JsonProperty(PropertyName = "user_id")]
        public int UserId;
        [JsonProperty(PropertyName = "username")]
        public string Username;
        [JsonProperty(PropertyName = "count300")]
        public int Count300;
        [JsonProperty(PropertyName = "count100")]
        public int Count100;
        [JsonProperty(PropertyName = "count50")]
        public int Count50;
        [JsonProperty(PropertyName = "playcount")]
        public int Playcount;
        [JsonProperty(PropertyName = "ranked_score")]
        public long RankedScore;
        [JsonProperty(PropertyName = "total_score")]
        public long TotalScore;
        [JsonProperty(PropertyName = "pp_rank")]
        public int GlobalRank;
        [JsonProperty(PropertyName = "level")]
        public float Level;
        [JsonProperty(PropertyName = "pp_raw")]
        public float PerformancePoints;
        [JsonProperty(PropertyName = "accuracy")]
        public float Accuracy;
        [JsonProperty(PropertyName = "count_rank_ss")]
        public int CountSS;
        [JsonProperty(PropertyName = "count_rank_s")]
        public int CountS;
        [JsonProperty(PropertyName = "count_rank_a")]
        public int CountA;
        [JsonProperty(PropertyName = "country")]
        public string Country;
        [JsonProperty(PropertyName = "pp_country_rank")]
        public int CountryRank;
        [JsonProperty(PropertyName = "events")]
        public List<Event> Events;

        // constructors
        public User() { }

        public User(dynamic userdata)
        {
            // TODO: parse userdata
        }
    }
}
