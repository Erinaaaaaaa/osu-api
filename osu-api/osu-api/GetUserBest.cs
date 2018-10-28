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
        /// Retrieves the top scores for a player. Defaults to 10.
        /// </summary>
        /// <param name="api_key">API key.</param>
        /// <param name="user_id">User ID.</param>
        /// <param name="mode">Gamemode to retrieve scores from.</param>
        /// <param name="limit">Limit (range: 1-100)</param>
        /// <returns>Returns a list of Score objects.</returns>
        public static List<UserScore> GetUserPerformanceByUserID(string api_key, int user_id, int? mode = null, int limit = 10)
        {
            var parameters = "";
            if (mode != null) parameters += $"&m={mode}";
            if (limit != 10) parameters += $"&limit={limit}";
            var resp =
                    new System.Net.WebClient().DownloadString(
                    $"https://osu.ppy.sh/api/get_user_best?u={user_id}&k={api_key}&type=id" + parameters);
            var scores = JsonConvert.DeserializeObject<List<UserScore>>(resp, DateTimeConverter);
            return scores;
        }

        //
        // FIX BOTTOM METHODS THE SAME WAY AS ABOVE
        //
        //
        //

        /// <summary>
        /// Retrieves the top scores for a player. Defaults to 10.
        /// </summary>
        /// <param name="api_key">API key.</param>
        /// <param name="user_id">User ID.</param>
        /// <param name="mode">Gamemode to retrieve scores from.</param>
        /// <param name="limit">Limit (range: 1-100)</param>
        /// <returns>Returns a list of Score objects.</returns>
        public static async Task<List<UserScore>> GetUserPerformanceByUserIDAsync(string api_key, int user_id, int? mode = null, int limit = 10)
        {
            var parameters = "";
            if (mode != null) parameters += $"&m={mode}";
            if (limit != 10) parameters += $"&limit={limit}";
            var resp =
                    await new System.Net.Http.HttpClient().GetStringAsync(
                        $"https://osu.ppy.sh/api/get_user_best?u={user_id}&k={api_key}&type=id" + parameters);
            var scores = JsonConvert.DeserializeObject<List<UserScore>>(resp, DateTimeConverter);
            return scores;
        }

        /// <summary>
        /// Retrieves the top scores for a player. Defaults to 10.
        /// </summary>
        /// <param name="api_key">API key.</param>
        /// <param name="username">Username.</param>
        /// <param name="mode">Gamemode to retrieve scores from.</param>
        /// <param name="limit">Limit (range: 1-100)</param>
        /// <returns>Returns a list of Score objects.</returns>
        public static List<UserScore> GetUserPerformanceByUsername(string api_key, string username, int? mode = null, int limit = 10)
        {
            var parameters = "";
            if (mode != null) parameters += $"&m={mode}";
            if (limit != 10) parameters += $"&limit={limit}";
            var resp =
                    new System.Net.WebClient().DownloadString(
                    $"https://osu.ppy.sh/api/get_user_best?u={username}&k={api_key}&type=string" + parameters);
            var scores = JsonConvert.DeserializeObject<List<UserScore>>(resp, DateTimeConverter);
            return scores;
        }

        /// <summary>
        /// Retrieves the top scores for a player. Defaults to 10.
        /// </summary>
        /// <param name="api_key">API key.</param>
        /// <param name="username">Username.</param>
        /// <param name="mode">Gamemode to retrieve scores from.</param>
        /// <param name="limit">Limit (range: 1-100)</param>
        /// <returns>Returns a list of Score objects.</returns>
        public static async Task<List<UserScore>> GetUserPerformanceByUsernameAsync(string api_key, string username, int? mode = null, int limit = 10)
        {
            var parameters = "";
            if (mode != null) parameters += $"&m={mode}";
            if (limit != 10) parameters += $"&limit={limit}";
            var resp =
                    await new System.Net.Http.HttpClient().GetStringAsync(
                        $"https://osu.ppy.sh/api/get_user_best?u={username}&k={api_key}&type=string" + parameters);
            var scores = JsonConvert.DeserializeObject<List<UserScore>>(resp, DateTimeConverter);
            return scores;
        }
    }
}
