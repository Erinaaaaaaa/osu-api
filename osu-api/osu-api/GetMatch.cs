using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using osu_api.Models;

namespace osu_api
{
    public partial class OsuApi
    {

        /// <summary>
        /// Retrieves match info for the specified ID.
        /// </summary>
        /// <param name="match_id">Match ID.</param>
        /// <param name="api_key">API key.</param>
        /// <returns>Returns a MPMatch object.</returns>
        public static MPMatch GetMatch(int match_id, string api_key)
        {
            var resp =
                new System.Net.WebClient().DownloadString(
                    $"https://osu.ppy.sh/api/get_match?mp={match_id}&k={api_key}");
            var mpgame = JsonConvert.DeserializeObject<MPMatch>(resp, DateTimeConverter);
            return mpgame;
        }

        /// <summary>
        /// Retrieves match info for the specified ID.
        /// </summary>
        /// <param name="match_id">Match ID.</param>
        /// <param name="api_key">API key.</param>
        /// <returns>Returns a MPMatch object.</returns>
        public static async Task<MPMatch> GetMatchAsync(int match_id, string api_key)
        {
            var resp =
                await new System.Net.Http.HttpClient().GetStringAsync(
                    $"https://osu.ppy.sh/api/get_match?mp={match_id}&k={api_key}");
            var mpgame = JsonConvert.DeserializeObject<MPMatch>(resp, DateTimeConverter);
            return mpgame;
        }
    }
}
