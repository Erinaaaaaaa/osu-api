using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using osu_api.Models.UserEvents;

namespace osu_api.Models
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

        // Serialization events
        [OnDeserialized]
        internal void FixEvents(StreamingContext ctx)
        {
            // Time to enjoy parsing 
            Console.WriteLine("[Debug] Ondeserialized reached!");

            List<Event> NewEvents = new List<Event>();
            foreach (Event e in Events)
            {
                var str = e.DisplayHTML;

                string[] regexList = new string[]{
                    "has submitted a new beatmap",
                    "has updated the beatmap",
                    "has been revived",
                    "has just been qualified",
                    @"<img src='\/images\/(?<grade>[A-Z]{1,2})_small\.png'\/> <b><a href='.+'>.+<\/a><\/b> achieved (<b>|.*)rank #(?<rank>[0-9]{1,4})(<\/b>|.*) on",
                    @"unlocked the \\""<b>(?<medalname>.*)<\/b>\\""medal",
                    "has lost first place on"
                };

                // Map ranked update events
                // Loved       
                // Graveyarded

                int i;
                bool success = false;
                Event e_2 = new Event();
                for (i = 0; i < regexList.Length; i++)
                {
                    Regex regex = new Regex(regexList[i]);
                    Match match = regex.Match(str);
                    if (match.Success)
                    {
                        success = true;                   
                        switch (i) {
                            case 0: // Beatmap submit
                                e_2 = new MapUpdateEvent {
                                    Date = e.Date,
                                    BeatmapID = e.BeatmapID,
                                    BeatmapsetID = e.BeatmapsetID,
                                    EpicFactor = e.EpicFactor,
                                    Action = MapUpdateEvent.MapUpdateAction.Submit};
                                break;
                            case 1: // Beatmap update
                                e_2 = new MapUpdateEvent {
                                    Date = e.Date,
                                    BeatmapID = e.BeatmapID,
                                    BeatmapsetID = e.BeatmapsetID,
                                    EpicFactor = e.EpicFactor,
                                    Action = MapUpdateEvent.MapUpdateAction.Update };
                                break;
                            case 2: // Beatmap revive
                                e_2 = new MapUpdateEvent {
                                    Date = e.Date,
                                    BeatmapID = e.BeatmapID,
                                    BeatmapsetID = e.BeatmapsetID,
                                    EpicFactor = e.EpicFactor,
                                    Action = MapUpdateEvent.MapUpdateAction.Revive };
                                break;
                            case 3: // Beatmap qualify/rank
                                e_2 = new MapRankedUpdateEvent {
                                    Date = e.Date,
                                    BeatmapID = e.BeatmapID,
                                    BeatmapsetID = e.BeatmapsetID,
                                    EpicFactor = e.EpicFactor,
                                    Action = MapRankedUpdateEvent.MapRankAction.Qualified }; // no choice lol
                                break;
                            case 4: // Rank achieved
                                e_2 = new MapScoreEvent
                                {
                                    Date = e.Date,
                                    BeatmapID = e.BeatmapID,
                                    BeatmapsetID = e.BeatmapsetID,
                                    EpicFactor = e.EpicFactor,
                                    MapScoreGrade = Convert.ToString(match.Groups["grade"].Value),
                                    MapRank = Convert.ToUInt32(match.Groups["rank"].Value),
                                };
                                break;
                            case 5: // Unlocked medal
                                e_2 = new AchievementEvent {
                                    Date = e.Date,
                                    BeatmapID = e.BeatmapID,
                                    BeatmapsetID = e.BeatmapsetID,
                                    EpicFactor = e.EpicFactor,
                                    AchievementName = Convert.ToString(match.Groups["medalname"].Value) };
                                break;
                            case 6: // Lost first place
                                e_2 = new FirstPlaceLostEvent {
                                    Date = e.Date,
                                    BeatmapID = e.BeatmapID,
                                    BeatmapsetID = e.BeatmapsetID,
                                    EpicFactor = e.EpicFactor,
                                };
                                break;
                            default:
                                break;
                        }
                        break;
                    }
                }
                if (success)
                    NewEvents.Add(e_2);
                else
                    Console.WriteLine("something sketchy happened");
            }
            Events = NewEvents;
        }
    }
}
