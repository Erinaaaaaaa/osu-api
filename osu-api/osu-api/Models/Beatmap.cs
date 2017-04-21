using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OtakuOverclocks.Utils.Models
{
    public class Beatmap
    {
        // variables
        
        [JsonProperty(PropertyName = "approved")]
        public int Approved; // 4 = loved, 3 = qualified, 2 = approved, 1 = ranked, 0 = pending, -1 = WIP, -2 = graveyard
        [JsonProperty(PropertyName = "approved_date")]
        public DateTime? ApprovedDate;
        [JsonProperty(PropertyName = "last_update")]
        public DateTime LastUpdate;
        [JsonProperty(PropertyName = "artist")]
        public string Artist;
        [JsonProperty(PropertyName = "beatmap_id")]
        public int MapID;
        [JsonProperty(PropertyName = "beatmapset_id")]
        public int MapsetID;
        [JsonProperty(PropertyName = "bpm")]
        public decimal BPM;
        [JsonProperty(PropertyName = "creator")]
        public string Mapper; 
        [JsonProperty(PropertyName = "difficultyrating")]
        public float StarDifficulty;
        [JsonProperty(PropertyName = "diff_size")]
        public decimal CircleSize;
        [JsonProperty(PropertyName = "diff_overall")]
        public decimal OverallDifficulty;
        [JsonProperty(PropertyName = "diff_approach")]
        public decimal ApproachRate;
        [JsonProperty(PropertyName = "diff_drain")]
        public decimal HPDrain;
        [JsonProperty(PropertyName = "hit_length")]
        public int DrainTime;
        [JsonProperty(PropertyName = "source")]
        public string Source;
        [JsonProperty(PropertyName = "genre_id")]
        public int Genre; // 0 = any, 1 = unspecified, 2 = video game, 3 = anime, 4 = rock, 5 = pop, 6 = other, 7 = novelty, 9 = hip hop, 10 = electronic (note that there's no 8)
        [JsonProperty(PropertyName = "language_id")]
        public int Language; // 0 = any, 1 = other, 2 = english, 3 = japanese, 4 = chinese, 5 = instrumental, 6 = korean, 7 = french, 8 = german, 9 = swedish, 10 = spanish, 11 = italian
        [JsonProperty(PropertyName = "title")]
        public string Title;
        [JsonProperty(PropertyName = "total_length")]
        public int TotalLength;
        [JsonProperty(PropertyName = "version")]
        public string Difficulty;
        [JsonProperty(PropertyName = "file_md5")]
        public string MD5Hash;
        [JsonProperty(PropertyName = "mode")]
        public int Gamemode;
        [JsonProperty(PropertyName = "tags")]
        public string Tags;
        [JsonProperty(PropertyName = "favorite_count")]
        public int FavoriteCount;
        [JsonProperty(PropertyName = "playcount")]
        public int Playcount;
        [JsonProperty(PropertyName = "passcount")]
        public int Passcount;
        [JsonProperty(PropertyName = "max_combo")]
        public int? MaxCombo;

        // constructors
        public Beatmap() { }
    }
}
