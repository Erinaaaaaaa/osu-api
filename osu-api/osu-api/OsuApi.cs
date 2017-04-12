using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu_api.Models;
using Newtonsoft.Json;
using System.Globalization;
using Newtonsoft.Json.Converters;

namespace osu_api
{
    public class OsuApi
    {
        public static readonly IsoDateTimeConverter DATE_TIME_CONVERTER = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };

        #region /get_user

        /// <summary>
        /// Retrieves the userdata of a player for a specific gamemode.
        /// </summary>
        /// <param name="user_id">User ID of the player.</param>
        /// <param name="api_key">Your osu! API key.</param>
        /// <param name="gamemode">Gamemode. Defaults to Standard</param>
        /// <param name="event_days">Days of events to return (between 1 and 31). Defaults to 1.</param>
        /// <returns>Returns an user object with the userdata if successful, null otherwise.</returns>
        public static User GetUser(int user_id, string api_key, int gamemode = 0, int event_days = 1)
        {
            try {
                var resp =
                    new System.Net.WebClient().DownloadString(
                        $"https://osu.ppy.sh/api/get_user?type=id&u={user_id}&m={gamemode}&k={api_key}&event_days={event_days}");
                var users = JsonConvert.DeserializeObject<List<User>>(resp, DATE_TIME_CONVERTER);
                return users[0];
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Retrieves the userdata of a player for a specific gamemode.
        /// </summary>
        /// <param name="user_id">User ID of the player.</param>
        /// <param name="api_key">Your osu! API key.</param>
        /// <param name="gamemode">Gamemode. Defaults to Standard</param>
        /// <param name="event_days">Days of events to return (between 1 and 31). Defaults to 1.</param>
        /// <returns>Returns an user object with the userdata if successful, null otherwise.</returns>
        public static async Task<User> GetUserAsync(int user_id, string api_key, int gamemode = 0, int event_days = 1)
        {
            try
            {
                var resp =
                    await new System.Net.Http.HttpClient().GetStringAsync(
                        $"https://osu.ppy.sh/api/get_user?type=id&u={user_id}&m={gamemode}&k={api_key}&event_days={event_days}");
                var users = JsonConvert.DeserializeObject<List<User>>(resp, DATE_TIME_CONVERTER);
                return users[0];
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Retrieves the userdata of a player for a specific gamemode.
        /// </summary>
        /// <param name="username">Username of the player.</param>
        /// <param name="api_key">Your osu! API key.</param>
        /// <param name="gamemode">Gamemode. Defaults to Standard</param>
        /// <param name="event_days">Days of event to return.</param>
        /// <returns>Returns an user object with the userdata if successful, null otherwise.</returns>
        public static User GetUser(string username, string api_key, int gamemode = 0, int event_days = 1)
        {
            try
            {
                var resp =
                   new System.Net.WebClient().DownloadString($"https://osu.ppy.sh/api/get_user?type=string&u={username}&m={gamemode}&k={api_key}&event_days={event_days}");
                var users = JsonConvert.DeserializeObject<List<User>>(resp, DATE_TIME_CONVERTER);
                return users[0];
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Retrieves the userdata of a player for a specific gamemode.
        /// </summary>
        /// <param name="username">Username of the player.</param>
        /// <param name="api_key">Your osu! API key.</param>
        /// <param name="gamemode">Gamemode. Defaults to Standard</param>
        /// <param name="event_days">Days of event to return.</param>
        /// <returns>Returns an user object with the userdata if successful, null otherwise.</returns>
        public static async Task<User> GetUserAsync(string username, string api_key, int gamemode = 0, int event_days = 1)
        {
            try
            {
                var resp =
                   await new System.Net.Http.HttpClient().GetStringAsync($"https://osu.ppy.sh/api/get_user?type=string&u={username}&m={gamemode}&k={api_key}&event_days={event_days}");
                var users = JsonConvert.DeserializeObject<List<User>>(resp, DATE_TIME_CONVERTER);
                return users[0];
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        #region /get_beatmaps

        /// <summary>
        /// Retrieves beatmap information for the specified hash.
        /// </summary>
        /// <param name="md5Hash">MD5 hash of the beatmap.</param>
        /// <param name="api_key">Your osu! API key.</param>
        /// <param name="autoconverts">Whether to show autoconverts or not.</param>
        /// <param name="limit">Maximum number of results. Range: 0-500</param>
        /// <param name="mode">Map gamemode.</param>
        /// <returns>Returns a Beatmap obejct if successful, null otherwise.</returns>
        public static Beatmap GetBeatmapFromHash(string md5Hash, string api_key, int? mode = null, bool autoconverts = false, int limit = 500)
        {
            try
            {
                var resp =
                        new System.Net.WebClient().DownloadString(
                            $"https://osu.ppy.sh/api/get_beatmaps?k={api_key}&h={md5Hash}&m={mode}&a={Convert.ToInt32(autoconverts)}&limit={limit}");
                var beatmaps = JsonConvert.DeserializeObject<List<Beatmap>>(resp, DATE_TIME_CONVERTER);
                return beatmaps[0];
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Retrieves beatmap information for the specified hash.
        /// </summary>
        /// <param name="md5Hash">MD5 hash of the beatmap.</param>
        /// <param name="api_key">Your osu! API key.</param>
        /// <param name="autoconverts">Whether to show autoconverts or not.</param>
        /// <param name="limit">Maximum number of results. Range: 0-500</param>
        /// <param name="mode">Map gamemode.</param>
        /// <returns>Returns a Beatmap obejct if successful, null otherwise.</returns>
        public static async Task<Beatmap> GetBeatmapFromHashAsync(string md5Hash, string api_key, int? mode = null, bool autoconverts = false, int limit = 500)
        {
            try
            {
                var resp =
                        await new System.Net.Http.HttpClient().GetStringAsync(
                            $"https://osu.ppy.sh/api/get_beatmaps?k={api_key}&h={md5Hash}&m={mode}&a={Convert.ToInt32(autoconverts)}&limit={limit}");
                var beatmaps = JsonConvert.DeserializeObject<List<Beatmap>>(resp, DATE_TIME_CONVERTER);
                return beatmaps[0];
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Retrieves beatmap information for the specified mapset.
        /// </summary>
        /// <param name="beatmapset_id">Mapset ID.</param>
        /// <param name="api_key">Your osu! API key.</param>
        /// <param name="autoconverts">Whether to show autoconverts or not.</param>
        /// <param name="limit">Maximum number of results. Range: 0-500</param>
        /// <param name="mode">Map gamemode.</param>
        /// <returns>Returns a list of Beatmap obejcts if successful, null otherwise.</returns>
        public static List<Beatmap> GetBeatmapsFromSetID(int beatmapset_id, string api_key, int? mode = null, bool autoconverts = false, int limit = 500)
        {
            try
            {
                var resp =
                        new System.Net.WebClient().DownloadString(
                            $"https://osu.ppy.sh/api/get_beatmaps?k={api_key}&s={beatmapset_id}&m={mode}&a={Convert.ToInt32(autoconverts)}&limit={limit}");
                var beatmaps = JsonConvert.DeserializeObject<List<Beatmap>>(resp, DATE_TIME_CONVERTER);
                return beatmaps;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Retrieves beatmap information for the specified mapset.
        /// </summary>
        /// <param name="beatmapset_id">Mapset ID.</param>
        /// <param name="api_key">Your osu! API key.</param>
        /// <param name="autoconverts">Whether to show autoconverts or not.</param>
        /// <param name="limit">Maximum number of results. Range: 0-500</param>
        /// <param name="mode">Map gamemode.</param>
        /// <returns>Returns a list of Beatmap obejcts if successful, null otherwise.</returns>
        public static async Task<List<Beatmap>> GetBeatmapsFromSetIDAsync(int beatmapset_id, string api_key, int? mode = null, bool autoconverts = false, int limit = 500)
        {
            try
            {
                var resp =
                        await new System.Net.Http.HttpClient().GetStringAsync(
                            $"https://osu.ppy.sh/api/get_beatmaps?k={api_key}&s={beatmapset_id}&m={mode}&a={Convert.ToInt32(autoconverts)}&limit={limit}");
                var beatmaps = JsonConvert.DeserializeObject<List<Beatmap>>(resp, DATE_TIME_CONVERTER);
                return beatmaps;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Retrieves beatmap information for the specified map.
        /// </summary>
        /// <param name="beatmap_id">Map ID.</param>
        /// <param name="api_key">Your osu! API key.</param>
        /// <param name="autoconverts">Whether to show autoconverts or not.</param>
        /// <param name="limit">Maximum number of results. Range: 0-500</param>
        /// <param name="mode">Map gamemode.</param>
        /// <returns>Returns a Beatmap obejct if successful, null otherwise.</returns>
        public static Beatmap GetBeatmapFromMapID(int beatmap_id, string api_key, int? mode = null, bool autoconverts = false, int limit = 500)
        {
            try
            {
                var resp =
                        new System.Net.WebClient().DownloadString(
                            $"https://osu.ppy.sh/api/get_beatmaps?k={api_key}&b={beatmap_id}&m={mode}&a={Convert.ToInt32(autoconverts)}&limit={limit}");
                var beatmaps = JsonConvert.DeserializeObject<List<Beatmap>>(resp, DATE_TIME_CONVERTER);
                return beatmaps[0];
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Retrieves beatmap information for the specified map.
        /// </summary>
        /// <param name="beatmap_id">Map ID.</param>
        /// <param name="api_key">Your osu! API key.</param>
        /// <param name="autoconverts">Whether to show autoconverts or not.</param>
        /// <param name="limit">Maximum number of results. Range: 0-500</param>
        /// <param name="mode">Map gamemode.</param>
        /// <returns>Returns a Beatmap obejct if successful, null otherwise.</returns>
        public static async Task<Beatmap> GetBeatmapFromMapIDAsync(int beatmap_id, string api_key, int? mode = null, bool autoconverts = false, int limit = 500)
        {
            try
            {
                var resp =
                        await new System.Net.Http.HttpClient().GetStringAsync(
                            $"https://osu.ppy.sh/api/get_beatmaps?k={api_key}&b={beatmap_id}&m={mode}&a={Convert.ToInt32(autoconverts)}&limit={limit}");
                var beatmaps = JsonConvert.DeserializeObject<List<Beatmap>>(resp, DATE_TIME_CONVERTER);
                return beatmaps[0];
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Retrieves beatmap information for the specified user.
        /// </summary>
        /// <param name="user_id">User ID.</param>
        /// <param name="api_key">Your osu! API key.</param>
        /// <param name="autoconverts">Whether to show autoconverts or not.</param>
        /// <param name="limit">Maximum number of results. Range: 0-500</param>
        /// <param name="mode">Map gamemode.</param>
        /// <returns>Returns a list of Beatmap obejcts if successful, null otherwise.</returns>
        public static List<Beatmap> GetBeatmapsFromUser(int user_id, string api_key, int? mode = null, bool autoconverts = false, int limit = 500)
        {
            try
            {
                var resp =
                        new System.Net.WebClient().DownloadString(
                            $"https://osu.ppy.sh/api/get_beatmaps?k={api_key}&u={user_id}&type=id&m={mode}&a={Convert.ToInt32(autoconverts)}&limit={limit}");
                var beatmaps = JsonConvert.DeserializeObject<List<Beatmap>>(resp, DATE_TIME_CONVERTER);
                return beatmaps;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Retrieves beatmap information for the specified user.
        /// </summary>
        /// <param name="user_id">User ID.</param>
        /// <param name="api_key">Your osu! API key.</param>
        /// <param name="autoconverts">Whether to show autoconverts or not.</param>
        /// <param name="limit">Maximum number of results. Range: 0-500</param>
        /// <param name="mode">Map gamemode.</param>
        /// <returns>Returns a list of Beatmap obejcts if successful, null otherwise.</returns>
        public static async Task<List<Beatmap>> GetBeatmapFromUserAsync(int user_id, string api_key, int? mode = null, bool autoconverts = false, int limit = 500)
        {
            try
            {
                var resp =
                        await new System.Net.Http.HttpClient().GetStringAsync(
                            $"https://osu.ppy.sh/api/get_beatmaps?k={api_key}&u={user_id}&type=id&m={mode}&a={Convert.ToInt32(autoconverts)}&limit={limit}");
                var beatmaps = JsonConvert.DeserializeObject<List<Beatmap>>(resp, DATE_TIME_CONVERTER);
                return beatmaps;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Retrieves beatmap information for the specified user.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="api_key">Your osu! API key.</param>
        /// <param name="autoconverts">Whether to show autoconverts or not.</param>
        /// <param name="limit">Maximum number of results. Range: 0-500</param>
        /// <param name="mode">Map gamemode.</param>
        /// <returns>Returns a list of Beatmap obejcts if successful, null otherwise.</returns>
        public static List<Beatmap> GetBeatmapsFromUser(string username, string api_key, int? mode = null, bool autoconverts = false, int limit = 500)
        {
            try
            {
                var resp =
                        new System.Net.WebClient().DownloadString(
                            $"https://osu.ppy.sh/api/get_beatmaps?k={api_key}&u={username}&type=string&m={mode}&a={Convert.ToInt32(autoconverts)}&limit={limit}");
                var beatmaps = JsonConvert.DeserializeObject<List<Beatmap>>(resp, DATE_TIME_CONVERTER);
                return beatmaps;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Retrieves beatmap information for the specified user.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="api_key">Your osu! API key.</param>
        /// <param name="autoconverts">Whether to show autoconverts or not.</param>
        /// <param name="limit">Maximum number of results. Range: 0-500</param>
        /// <param name="mode">Map gamemode.</param>
        /// <returns>Returns a list of Beatmap obejcts if successful, null otherwise.</returns>
        public static async Task<List<Beatmap>> GetBeatmapFromUserAsync(string username, string api_key, int? mode = null, bool autoconverts = false, int limit = 500)
        {
            try
            {
                var resp =
                        await new System.Net.Http.HttpClient().GetStringAsync(
                            $"https://osu.ppy.sh/api/get_beatmaps?k={api_key}&u={username}&type=string&m={mode}&a={Convert.ToInt32(autoconverts)}&limit={limit}");
                var beatmaps = JsonConvert.DeserializeObject<List<Beatmap>>(resp, DATE_TIME_CONVERTER);
                return beatmaps;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Retrieves beatmap information for the specified user.
        /// </summary>
        /// <param name="user">User object.</param>
        /// <param name="api_key">Your osu! API key.</param>
        /// <param name="autoconverts">Whether to show autoconverts or not.</param>
        /// <param name="limit">Maximum number of results. Range: 0-500</param>
        /// <param name="mode">Map gamemode.</param>
        /// <returns>Returns a list of Beatmap obejcts if successful, null otherwise.</returns>
        public static List<Beatmap> GetBeatmapsFromUser(User user, string api_key, int? mode = null, bool autoconverts = false, int limit = 500)
        {
            try
            {
                var resp =
                        new System.Net.WebClient().DownloadString(
                            $"https://osu.ppy.sh/api/get_beatmaps?k={api_key}&u={user.UserId}&type=id&m={mode}&a={Convert.ToInt32(autoconverts)}&limit={limit}");
                var beatmaps = JsonConvert.DeserializeObject<List<Beatmap>>(resp, DATE_TIME_CONVERTER);
                return beatmaps;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Retrieves beatmap information for the specified user.
        /// </summary>
        /// <param name="user">User object.</param>
        /// <param name="api_key">Your osu! API key.</param>
        /// <param name="autoconverts">Whether to show autoconverts or not.</param>
        /// <param name="limit">Maximum number of results. Range: 0-500</param>
        /// <param name="mode">Map gamemode.</param>
        /// <returns>Returns a list of Beatmap obejcts if successful, null otherwise.</returns>
        public static async Task<List<Beatmap>> GetBeatmapFromUserAsync(User user, string api_key, int? mode = null, bool autoconverts = false, int limit = 500)
        {
            try
            {
                var resp =
                        await new System.Net.Http.HttpClient().GetStringAsync(
                            $"https://osu.ppy.sh/api/get_beatmaps?k={api_key}&u={user.UserId}&type=id&m={mode}&a={Convert.ToInt32(autoconverts)}&limit={limit}");
                var beatmaps = JsonConvert.DeserializeObject<List<Beatmap>>(resp, DATE_TIME_CONVERTER);
                return beatmaps;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Retrieves ranked beatmap information since the specified date.
        /// </summary>
        /// <param name="time">Date since when beatmaps should be returned.</param>
        /// <param name="api_key">Your osu! API key.</param>
        /// <param name="autoconverts">Whether to show autoconverts or not.</param>
        /// <param name="limit">Maximum number of results. Range: 0-500</param>
        /// <param name="mode">Map gamemode.</param>
        /// <returns>Returns a list of Beatmap obejcts if successful, null otherwise.</returns>
        public static List<Beatmap> GetRankedBeatmapsSince(DateTime time, string api_key, int? mode = null, bool autoconverts = false, int limit = 500)
        {
            try
            {
                var resp =
                        new System.Net.WebClient().DownloadString(
                            $"https://osu.ppy.sh/api/get_beatmaps?k={api_key}&since={time.ToString("yyyy - MM - dd HH: mm:ss")}&m={mode}&a={Convert.ToInt32(autoconverts)}&limit={limit}");
                var beatmaps = JsonConvert.DeserializeObject<List<Beatmap>>(resp, DATE_TIME_CONVERTER);
                return beatmaps;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Retrieves ranked beatmap information since the specified date.
        /// </summary>
        /// <param name="time">Date since when beatmaps should be returned.</param>
        /// <param name="api_key">Your osu! API key.</param>
        /// <param name="autoconverts">Whether to show autoconverts or not.</param>
        /// <param name="limit">Maximum number of results. Range: 0-500</param>
        /// <param name="mode">Map gamemode.</param>
        /// <returns>Returns a list of Beatmap obejcts if successful, null otherwise.</returns>
        public static async Task<List<Beatmap>> GetRankedBeatmapsSinceAsync(DateTime time, string api_key, int? mode = null, bool autoconverts = false, int limit = 500)
        {
            try
            {
                var resp =
                        await new System.Net.Http.HttpClient().GetStringAsync(
                            $"https://osu.ppy.sh/api/get_beatmaps?k={api_key}&since={time.ToString("yyyy - MM - dd HH: mm:ss")}&m={mode}&a={Convert.ToInt32(autoconverts)}&limit={limit}");
                var beatmaps = JsonConvert.DeserializeObject<List<Beatmap>>(resp, DATE_TIME_CONVERTER);
                return beatmaps;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        #region /get_scores

        /// <summary>
        /// Retrieves the scoreboard for a map, eventually for a specific user or mods.
        /// </summary>
        /// <param name="beatmap_id">Map ID.</param>
        /// <param name="api_key">API key.</param>
        /// <param name="user_id">User ID.</param>
        /// <param name="mods">Mods.</param>
        /// <param name="limit">Limit (range: 1-100)</param>
        /// <returns>Returns a list of Score objects if successfull, null otherwise.</returns>
        public static List<Score> GetScoreboard(int beatmap_id, string api_key, int? user_id = null, int? mods = null, int limit = 50)
        {
            try
            {
                var resp =
                    new System.Net.WebClient().DownloadString(
                        $"https://osu.ppy.sh/api/get_scores?type=id&u={user_id}&b={beatmap_id}&k={api_key}&mods={mods}&limit={limit}");
                var scores = JsonConvert.DeserializeObject<List<Score>>(resp, DATE_TIME_CONVERTER);
                return scores;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Retrieves the scoreboard for a map, eventually for a specific user or mods.
        /// </summary>
        /// <param name="beatmap_id">Map ID.</param>
        /// <param name="api_key">API key.</param>
        /// <param name="user_id">User ID.</param>
        /// <param name="mods">Mods.</param>
        /// <param name="limit">Limit (range: 1-100)</param>
        /// <returns>Returns a list of Score objects if successfull, null otherwise.</returns>
        public static async Task<List<Score>> GetScoreboardAsync(int beatmap_id, string api_key, int? user_id = null, int? mods = null, int limit = 50)
        {
            try
            {
                var resp =
                    await new System.Net.Http.HttpClient().GetStringAsync(
                        $"https://osu.ppy.sh/api/get_scores?type=id&u={user_id}&b={beatmap_id}&k={api_key}&mods={mods}&limit={limit}");
                var scores = JsonConvert.DeserializeObject<List<Score>>(resp, DATE_TIME_CONVERTER);
                return scores;
            }
            catch (Exception)
            {
                return null;
            }
        }

        ///// <summary>
        ///// Retrieves the scoreboard for a map, eventually for a specific user or mods.
        ///// </summary>
        ///// <param name="beatmap_id">Map ID.</param>
        ///// <param name="api_key">API key.</param>
        ///// <param name="username">Username.</param>
        ///// <param name="mods">Mods.</param>
        ///// <param name="limit">Limit (range: 1-100)</param>
        ///// <returns>Returns a list of Score objects if successfull, null otherwise.</returns>
        //public static List<Score> GetScoreboard(int beatmap_id, string api_key, string username = null, int? mods = null, int limit = 50)
        //{
        //    try
        //    {
        //        var resp =
        //            new System.Net.WebClient().DownloadString(
        //                $"https://osu.ppy.sh/api/get_scores?type=string&u={username}&b={beatmap_id}&k={api_key}&mods={mods}&limit={limit}");
        //        var scores = JsonConvert.DeserializeObject<List<Score>>(resp, DATE_TIME_CONVERTER);
        //        return scores;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

        ///// <summary>
        ///// Retrieves the scoreboard for a map, eventually for a specific user or mods.
        ///// </summary>
        ///// <param name="beatmap_id">Map ID.</param>
        ///// <param name="api_key">API key.</param>
        ///// <param name="username">Username.</param>
        ///// <param name="mods">Mods.</param>
        ///// <param name="limit">Limit (range: 1-100)</param>
        ///// <returns>Returns a list of Score objects if successfull, null otherwise.</returns>
        //public static async Task<List<Score>> GetScoreboardAsync(int beatmap_id, string api_key, string username = null, int? mods = null, int limit = 50)
        //{
        //    try
        //    {
        //        var resp =
        //            await new System.Net.Http.HttpClient().GetStringAsync(
        //                $"https://osu.ppy.sh/api/get_scores?type=string&u={username}&b={beatmap_id}&k={api_key}&mods={mods}&limit={limit}");
        //        var scores = JsonConvert.DeserializeObject<List<Score>>(resp, DATE_TIME_CONVERTER);
        //        return scores;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

        #endregion

        #region /get_user_best

        /// <summary>
        /// Retrieves the top scores for a player. Defaults to 10.
        /// </summary>
        /// <param name="beatmap_id">Map ID.</param>
        /// <param name="api_key">API key.</param>
        /// <param name="user_id">User ID.</param>
        /// <param name="mode">Gamemode to retrieve scores from.</param>
        /// <param name="limit">Limit (range: 1-100)</param>
        /// <returns>Returns a list of Score objects if successfull, null otherwise.</returns>
        public static List<UserScore> GetUserPerformanceByUserID(string api_key, int? user_id = null, int? mode = null, int limit = 10)
        {
            try
            {
                var resp =
                    new System.Net.WebClient().DownloadString(
                    $"https://osu.ppy.sh/api/get_user_best?type=id&u={user_id}&k={api_key}&mode={mode}&limit={limit}&type=id");
                var scores = JsonConvert.DeserializeObject<List<UserScore>>(resp, DATE_TIME_CONVERTER);
                return scores;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Retrieves the top scores for a player. Defaults to 10.
        /// </summary>
        /// <param name="beatmap_id">Map ID.</param>
        /// <param name="api_key">API key.</param>
        /// <param name="user_id">User ID.</param>
        /// <param name="mode">Gamemode to retrieve scores from.</param>
        /// <param name="limit">Limit (range: 1-100)</param>
        /// <returns>Returns a list of Score objects if successfull, null otherwise.</returns>
        public static async Task<List<UserScore>> GetUserPerformanceByUserIDAsync(string api_key, int? user_id = null, int? mode = null, int limit = 10)
        {
            try
            {
                var resp =
                    await new System.Net.Http.HttpClient().GetStringAsync(
                        $"https://osu.ppy.sh/api/get_user_best?type=id&u={user_id}&k={api_key}&mode={mode}&limit={limit}&type=id");
                var scores = JsonConvert.DeserializeObject<List<UserScore>>(resp, DATE_TIME_CONVERTER);
                return scores;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Retrieves the top scores for a player. Defaults to 10.
        /// </summary>
        /// <param name="beatmap_id">Map ID.</param>
        /// <param name="api_key">API key.</param>
        /// <param name="username">Username.</param>
        /// <param name="mode">Gamemode to retrieve scores from.</param>
        /// <param name="limit">Limit (range: 1-100)</param>
        /// <returns>Returns a list of Score objects if successfull, null otherwise.</returns>
        public static List<UserScore> GetUserPerformanceByUsername(string api_key, string username, int? mode = null, int limit = 10)
        {
            try
            {
                var resp =
                    new System.Net.WebClient().DownloadString(
                    $"https://osu.ppy.sh/api/get_user_best?type=id&u={username}&k={api_key}&mode={mode}&limit={limit}&type=string");
                var scores = JsonConvert.DeserializeObject<List<UserScore>>(resp, DATE_TIME_CONVERTER);
                return scores;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Retrieves the top scores for a player. Defaults to 10.
        /// </summary>
        /// <param name="beatmap_id">Map ID.</param>
        /// <param name="api_key">API key.</param>
        /// <param name="username">Username.</param>
        /// <param name="mode">Gamemode to retrieve scores from.</param>
        /// <param name="limit">Limit (range: 1-100)</param>
        /// <returns>Returns a list of Score objects if successfull, null otherwise.</returns>
        public static async Task<List<UserScore>> GetUserPerformanceByUsernameAsync(string api_key, string username, int? mode = null, int limit = 10)
        {
            try
            {
                var resp =
                    await new System.Net.Http.HttpClient().GetStringAsync(
                        $"https://osu.ppy.sh/api/get_user_best?type=id&u={username}&k={api_key}&mode={mode}&limit={limit}&type=string");
                var scores = JsonConvert.DeserializeObject<List<UserScore>>(resp, DATE_TIME_CONVERTER);
                return scores;
            }
            catch (Exception)
            {
                return null;
            }
        }


        #endregion

        #region /get_match

        /// <summary>
        /// Retrieves match info for the specified ID.
        /// </summary>
        /// <param name="match_id">Match ID.</param>
        /// <param name="api_key">API key.</param>
        /// <returns>Returns a MPMatch object if successfull, null otherwise.</returns>
        public static MPMatch GetMatch(int match_id, string api_key)
        {
            try
            {
                var resp =
                    new System.Net.WebClient().DownloadString(
                        $"https://osu.ppy.sh/api/get_match?mp={match_id}&k={api_key}");
                var mpgame = JsonConvert.DeserializeObject<MPMatch>(resp, DATE_TIME_CONVERTER);
                return mpgame;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Retrieves match info for the specified ID.
        /// </summary>
        /// <param name="match_id">Match ID.</param>
        /// <param name="api_key">API key.</param>
        /// <returns>Returns a MPMatch object if successfull, null otherwise.</returns>
        public static async Task<MPMatch> GetMatchAsync(int match_id, string api_key)
        {
            try
            {
                var resp =
                    await new System.Net.Http.HttpClient().GetStringAsync(
                        $"https://osu.ppy.sh/api/get_match?mp={match_id}&k={api_key}");
                var mpgame = JsonConvert.DeserializeObject<MPMatch>(resp, DATE_TIME_CONVERTER);
                return mpgame;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion
    }
}
