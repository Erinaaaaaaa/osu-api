using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace osu_api.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Event
    {
        [JsonProperty(PropertyName = "display_html")]
        internal string DisplayHTML;
        [JsonProperty(PropertyName = "beatmap_id")]
        public int BeatmapID;
        [JsonProperty(PropertyName = "beatmapset_id")]
        public int BeatmapsetID;
        [JsonProperty(PropertyName = "date")]
        public DateTime Date;
        [JsonProperty(PropertyName = "epicfactor")]
        public int EpicFactor;

        // constructors
        public Event() { }
        public Event(dynamic event_data)
        {
            // TODO: parse event data
        }
    }
}
