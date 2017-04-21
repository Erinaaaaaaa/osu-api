using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OtakuOverclocks.Utils.Models
{
    public class MPGame
    {
        [JsonProperty(PropertyName = "game_id")]
        public int GameID;
        [JsonProperty(PropertyName = "start_time")]
        public DateTime StartTime;
        [JsonProperty(PropertyName = "end_time")]
        public DateTime EndTime;
        [JsonProperty(PropertyName = "beatmap_id")]
        public int BeatmapID;
        [JsonProperty(PropertyName = "play_mode")]
        public int Gamemode;
        [JsonProperty(PropertyName = "match_type")]
        public int MatchType; // unused
        [JsonProperty(PropertyName = "scoring_type")]
        public int ScoringType;
        [JsonProperty(PropertyName = "team_type")]
        public int TeamType;
        [JsonProperty(PropertyName = "mods")]
        public int Mods;
        [JsonProperty(PropertyName = "scores")]
        public List<MPScore> Scores;
    }
}
