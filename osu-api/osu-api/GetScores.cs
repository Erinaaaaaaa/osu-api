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
        /// Retrieves the scoreboard for a map, eventually for a specific user or mods.
        /// </summary>
        /// <param name="beatmap_id">Map ID.</param>
        /// <param name="api_key">API key.</param>
        /// <param name="user_id">User ID.</param>
        /// <param name="mods">Mods.</param>
        /// <param name="limit">Limit (range: 1-100)</param>
        /// <returns>Returns a list of Score objects.</returns>
        public static List<Score> GetScoreboard(int beatmap_id, string api_key, int? user_id = null, int? mods = null, int limit = 50)
        {
            var parameters = "";
            if (user_id != null) parameters += $"&u={user_id}&type=id";
            if (mods != null) parameters += $"&mods={mods}";
            if (limit != 50) parameters += $"&limit={limit}";
            var resp =
                    new System.Net.WebClient().DownloadString(
                        $"https://osu.ppy.sh/api/get_scores?b={beatmap_id}&k={api_key}" + parameters);
            var scores = JsonConvert.DeserializeObject<List<Score>>(resp, DateTimeConverter);
            return scores;
        }

        /// <summary>
        /// Retrieves the scoreboard for a map, eventually for a specific user or mods.
        /// </summary>
        /// <param name="beatmap_id">Map ID.</param>
        /// <param name="api_key">API key.</param>
        /// <param name="user_id">User ID.</param>
        /// <param name="mods">Mods.</param>
        /// <param name="limit">Limit (range: 1-100)</param>
        /// <returns>Returns a list of Score objects.</returns>
        public static async Task<List<Score>> GetScoreboardAsync(int beatmap_id, string api_key, int? user_id = null, int? mods = null, int limit = 50)
        {
            var parameters = "";
            if (user_id != null) parameters += $"&u={user_id}&type=id";
            if (mods != null) parameters += $"&mods={mods}";
            if (limit != 50) parameters += $"&limit={limit}";
            var resp =
                    await new System.Net.Http.HttpClient().GetStringAsync(
                        $"https://osu.ppy.sh/api/get_scores?b={beatmap_id}&k={api_key}" + parameters);
            var scores = JsonConvert.DeserializeObject<List<Score>>(resp, DateTimeConverter);
            return scores;
        }

        /// <summary>
        /// Retrieves the scoreboard for a map, eventually for a specific user or mods.
        /// </summary>
        /// <param name="beatmap_id">Map ID.</param>
        /// <param name="api_key">API key.</param>
        /// <param name="username">Username.</param>
        /// <param name="mods">Mods.</param>
        /// <param name="limit">Limit (range: 1-100)</param>
        /// <returns>Returns a list of Score objects.</returns>
        public static List<Score> GetScoreboard(int beatmap_id, string api_key, string username = null, int? mods = null, int limit = 50)
        {
            var parameters = "";
            if (username != null) parameters += $"&u={username}&type=string";
            if (mods != null) parameters += $"&mods={mods}";
            if (limit != 50) parameters += $"&limit={limit}";
            var resp =
                    new System.Net.WebClient().DownloadString(
                        $"https://osu.ppy.sh/api/get_scores?b={beatmap_id}&k={api_key}" + parameters);
            var scores = JsonConvert.DeserializeObject<List<Score>>(resp, DateTimeConverter);
            return scores;
        }

        /// <summary>
        /// Retrieves the scoreboard for a map, eventually for a specific user or mods.
        /// </summary>
        /// <param name="beatmap_id">Map ID.</param>
        /// <param name="api_key">API key.</param>
        /// <param name="username">Username.</param>
        /// <param name="mods">Mods.</param>
        /// <param name="limit">Limit (range: 1-100)</param>
        /// <returns>Returns a list of Score objects.</returns>
        public static async Task<List<Score>> GetScoreboardAsync(int beatmap_id, string api_key, string username = null, int? mods = null, int limit = 50)
        {
            var parameters = "";
            if (username != null) parameters += $"&u={username}&type=string";
            if (mods != null) parameters += $"&mods={mods}";
            if (limit != 50) parameters += $"&limit={limit}";
            var resp =
                    await new System.Net.Http.HttpClient().GetStringAsync(
                        $"https://osu.ppy.sh/api/get_scores?b={beatmap_id}&k={api_key}" + parameters);
            var scores = JsonConvert.DeserializeObject<List<Score>>(resp, DateTimeConverter);
            return scores;
        }
    }
}
