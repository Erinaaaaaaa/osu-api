using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OtakuOverclocks.Utils.Models
{
    public class MPMatch
    {
        [JsonProperty(PropertyName = "match")]
        public MPMetadata MatchInfo;
        [JsonProperty(PropertyName = "games")]
        public List<MPGame> MPGames;
    }
}
