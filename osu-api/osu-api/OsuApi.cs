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
        public static readonly IsoDateTimeConverter DateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };

        #region /get_user

        /// <summary>
        /// Retrieves the userdata of a player for a specific gamemode.
        /// </summary>
        /// <param name="user_id">User ID of the player.</param>
        /// <param name="api_key">Your osu! API key.</param>
        /// <param name="gamemode">Gamemode. Defaults to Standard</param>
        /// <param name="event_days">Days of events to return (between 1 and 31). Defaults to 1.</param>
        /// <returns>Returns an user object with the userdata.</returns>
        public static User GetUser(int user_id, string api_key, int gamemode = 0, int event_days = 1)
        {
            var resp =
                    new System.Net.WebClient().DownloadString(
                        $"https://osu.ppy.sh/api/get_user?type=id&u={user_id}&k={api_key}&m={gamemode}&event_days={event_days}");
                var users = JsonConvert.DeserializeObject<List<User>>(resp, DateTimeConverter);
                return users[0];    
            
        }

        /// <summary>
        /// Retrieves the userdata of a player for a specific gamemode.
        /// </summary>
        /// <param name="user_id">User ID of the player.</param>
        /// <param name="api_key">Your osu! API key.</param>
        /// <param name="gamemode">Gamemode. Defaults to Standard</param>
        /// <param name="event_days">Days of events to return (between 1 and 31). Defaults to 1.</param>
        /// <returns>Returns an user object with the userdata.</returns>
        public static async Task<User> GetUserAsync(int user_id, string api_key, int gamemode = 0, int event_days = 1)
        {
           
                var resp =
                    await new System.Net.Http.HttpClient().GetStringAsync(
                        $"https://osu.ppy.sh/api/get_user?type=id&u={user_id}&m={gamemode}&k={api_key}&event_days={event_days}");
                var users = JsonConvert.DeserializeObject<List<User>>(resp, DateTimeConverter);
                return users[0];
        }

        /// <summary>
        /// Retrieves the userdata of a player for a specific gamemode.
        /// </summary>
        /// <param name="username">Username of the player.</param>
        /// <param name="api_key">Your osu! API key.</param>
        /// <param name="gamemode">Gamemode. Defaults to Standard</param>
        /// <param name="event_days">Days of event to return.</param>
        /// <returns>Returns an user object with the userdata.</returns>
        public static User GetUser(string username, string api_key, int gamemode = 0, int event_days = 1)
        {
                var resp =
                   new System.Net.WebClient().DownloadString($"https://osu.ppy.sh/api/get_user?type=string&u={username}&m={gamemode}&k={api_key}&event_days={event_days}");
                var users = JsonConvert.DeserializeObject<List<User>>(resp, DateTimeConverter);
                return users[0];
        }

        /// <summary>
        /// Retrieves the userdata of a player for a specific gamemode.
        /// </summary>
        /// <param name="username">Username of the player.</param>
        /// <param name="api_key">Your osu! API key.</param>
        /// <param name="gamemode">Gamemode. Defaults to Standard</param>
        /// <param name="event_days">Days of event to return.</param>
        /// <returns>Returns an user object with the userdata.</returns>
        public static async Task<User> GetUserAsync(string username, string api_key, int gamemode = 0, int event_days = 1)
        {
                var resp =
                   await new System.Net.Http.HttpClient().GetStringAsync($"https://osu.ppy.sh/api/get_user?type=string&u={username}&m={gamemode}&k={api_key}&event_days={event_days}");
                var users = JsonConvert.DeserializeObject<List<User>>(resp, DateTimeConverter);
                return users[0];
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
        /// <returns>Returns a Beatmap obejct.</returns>
        public static Beatmap GetBeatmapFromHash(string md5Hash, string api_key, int? mode = null, bool? autoconverts = null, int limit = 500)
        {
            // &m={mode}&a={Convert.ToInt32(autoconverts)}&limit={limit}
            var parameters = "";
            if (mode != null) parameters += $"&m={mode}";
            if (autoconverts != null) parameters += $"&a={Convert.ToInt32(autoconverts)}";
            if (limit != 500) parameters += $"&limit={limit}";
            var resp =
                    new System.Net.WebClient().DownloadString(
                        $"https://osu.ppy.sh/api/get_beatmaps?k={api_key}&h={md5Hash}" + parameters);
            var beatmaps = JsonConvert.DeserializeObject<List<Beatmap>>(resp, DateTimeConverter);
            return beatmaps[0];
        }

        /// <summary>
        /// Retrieves beatmap information for the specified hash.
        /// </summary>
        /// <param name="md5Hash">MD5 hash of the beatmap.</param>
        /// <param name="api_key">Your osu! API key.</param>
        /// <param name="autoconverts">Whether to show autoconverts or not.</param>
        /// <param name="limit">Maximum number of results. Range: 0-500</param>
        /// <param name="mode">Map gamemode.</param>
        /// <returns>Returns a Beatmap obejct.</returns>
        public static async Task<Beatmap> GetBeatmapFromHashAsync(string md5Hash, string api_key, int? mode = null, bool? autoconverts = null, int limit = 500)
        {
            var parameters = "";
            if (mode != null) parameters += $"&m={mode}";
            if (autoconverts != null) parameters += $"&a={Convert.ToInt32(autoconverts)}";
            if (limit != 500) parameters += $"&limit={limit}";
            var resp =
                    await new System.Net.Http.HttpClient().GetStringAsync(
                        $"https://osu.ppy.sh/api/get_beatmaps?k={api_key}&h={md5Hash}" + parameters);
            var beatmaps = JsonConvert.DeserializeObject<List<Beatmap>>(resp, DateTimeConverter);
            return beatmaps[0];
        }

        /// <summary>
        /// Retrieves beatmap information for the specified mapset.
        /// </summary>
        /// <param name="beatmapset_id">Mapset ID.</param>
        /// <param name="api_key">Your osu! API key.</param>
        /// <param name="autoconverts">Whether to show autoconverts or not.</param>
        /// <param name="limit">Maximum number of results. Range: 0-500</param>
        /// <param name="mode">Map gamemode.</param>
        /// <returns>Returns a list of Beatmap obejcts.</returns>
        public static List<Beatmap> GetBeatmapsFromSetID(int beatmapset_id, string api_key, int? mode = null, bool? autoconverts = null, int limit = 500)
        {
            var parameters = "";
            if (mode != null) parameters += $"&m={mode}";
            if (autoconverts != null) parameters += $"&a={Convert.ToInt32(autoconverts)}";
            if (limit != 500) parameters += $"&limit={limit}";
            if (mode != null) parameters += $"&m={mode}";

                var resp =
                        new System.Net.WebClient().DownloadString(
                            $"https://osu.ppy.sh/api/get_beatmaps?k={api_key}&s={beatmapset_id}" + parameters);
                var beatmaps = JsonConvert.DeserializeObject<List<Beatmap>>(resp, DateTimeConverter);
                return beatmaps;
        }

        /// <summary>
        /// Retrieves beatmap information for the specified mapset.
        /// </summary>
        /// <param name="beatmapset_id">Mapset ID.</param>
        /// <param name="api_key">Your osu! API key.</param>
        /// <param name="autoconverts">Whether to show autoconverts or not.</param>
        /// <param name="limit">Maximum number of results. Range: 0-500</param>
        /// <param name="mode">Map gamemode.</param>
        /// <returns>Returns a list of Beatmap obejcts.</returns>
        public static async Task<List<Beatmap>> GetBeatmapsFromSetIDAsync(int beatmapset_id, string api_key, int? mode = null, bool? autoconverts = null, int limit = 500)
        {
            var parameters = "";
            if (mode != null) parameters += $"&m={mode}";
            if (autoconverts != null) parameters += $"&a={Convert.ToInt32(autoconverts)}";
            if (limit != 500) parameters += $"&limit={limit}";
            var resp =
                        await new System.Net.Http.HttpClient().GetStringAsync(
                            $"https://osu.ppy.sh/api/get_beatmaps?k={api_key}&s={beatmapset_id}" + parameters);
                var beatmaps = JsonConvert.DeserializeObject<List<Beatmap>>(resp, DateTimeConverter);
                return beatmaps;
        }

        /// <summary>
        /// Retrieves beatmap information for the specified map.
        /// </summary>
        /// <param name="beatmap_id">Map ID.</param>
        /// <param name="api_key">Your osu! API key.</param>
        /// <param name="autoconverts">Whether to show autoconverts or not.</param>
        /// <param name="limit">Maximum number of results. Range: 0-500</param>
        /// <param name="mode">Map gamemode.</param>
        /// <returns>Returns a Beatmap obejct.</returns>
        public static Beatmap GetBeatmapFromMapID(int beatmap_id, string api_key, int? mode = null, bool? autoconverts = null, int limit = 500)
        {
            var parameters = "";
            if (mode != null) parameters += $"&m={mode}";
            if (autoconverts != null) parameters += $"&a={Convert.ToInt32(autoconverts)}";
            if (limit != 500) parameters += $"&limit={limit}";
            var resp =
                        new System.Net.WebClient().DownloadString(
                            $"https://osu.ppy.sh/api/get_beatmaps?k={api_key}&b={beatmap_id}" + parameters);
                var beatmaps = JsonConvert.DeserializeObject<List<Beatmap>>(resp, DateTimeConverter);
                return beatmaps[0];
        }

        /// <summary>
        /// Retrieves beatmap information for the specified map.
        /// </summary>
        /// <param name="beatmap_id">Map ID.</param>
        /// <param name="api_key">Your osu! API key.</param>
        /// <param name="autoconverts">Whether to show autoconverts or not.</param>
        /// <param name="limit">Maximum number of results. Range: 0-500</param>
        /// <param name="mode">Map gamemode.</param>
        /// <returns>Returns a Beatmap obejct.</returns>
        public static async Task<Beatmap> GetBeatmapFromMapIDAsync(int beatmap_id, string api_key, int? mode = null, bool? autoconverts = null, int limit = 500)
        {
            var parameters = "";
            if (mode != null) parameters += $"&m={mode}";
            if (autoconverts != null) parameters += $"&a={Convert.ToInt32(autoconverts)}";
            if (limit != 500) parameters += $"&limit={limit}";
            var resp =
                        await new System.Net.Http.HttpClient().GetStringAsync(
                            $"https://osu.ppy.sh/api/get_beatmaps?k={api_key}&b={beatmap_id}" + parameters);
                var beatmaps = JsonConvert.DeserializeObject<List<Beatmap>>(resp, DateTimeConverter);
                return beatmaps[0];
        }

        /// <summary>
        /// Retrieves beatmap information for the specified user.
        /// </summary>
        /// <param name="user_id">User ID.</param>
        /// <param name="api_key">Your osu! API key.</param>
        /// <param name="autoconverts">Whether to show autoconverts or not.</param>
        /// <param name="limit">Maximum number of results. Range: 0-500</param>
        /// <param name="mode">Map gamemode.</param>
        /// <returns>Returns a list of Beatmap obejcts.</returns>
        public static List<Beatmap> GetBeatmapsFromUser(int user_id, string api_key, int? mode = null, bool? autoconverts = null, int limit = 500)
        {
            var parameters = "";
            if (mode != null) parameters += $"&m={mode}";
            if (autoconverts != null) parameters += $"&a={Convert.ToInt32(autoconverts)}";
            if (limit != 500) parameters += $"&limit={limit}";
            var resp =
                        new System.Net.WebClient().DownloadString(
                            $"https://osu.ppy.sh/api/get_beatmaps?k={api_key}&u={user_id}&type=id"+parameters);
                var beatmaps = JsonConvert.DeserializeObject<List<Beatmap>>(resp, DateTimeConverter);
                return beatmaps;
        }

        /// <summary>
        /// Retrieves beatmap information for the specified user.
        /// </summary>
        /// <param name="user_id">User ID.</param>
        /// <param name="api_key">Your osu! API key.</param>
        /// <param name="autoconverts">Whether to show autoconverts or not.</param>
        /// <param name="limit">Maximum number of results. Range: 0-500</param>
        /// <param name="mode">Map gamemode.</param>
        /// <returns>Returns a list of Beatmap obejcts.</returns>
        public static async Task<List<Beatmap>> GetBeatmapFromUserAsync(int user_id, string api_key, int? mode = null, bool? autoconverts = null, int limit = 500)
        {
            var parameters = "";
            if (mode != null) parameters += $"&m={mode}";
            if (autoconverts != null) parameters += $"&a={Convert.ToInt32(autoconverts)}";
            if (limit != 500) parameters += $"&limit={limit}";
            var resp =
                        await new System.Net.Http.HttpClient().GetStringAsync(
                            $"https://osu.ppy.sh/api/get_beatmaps?k={api_key}&u={user_id}&type=id" + parameters);
                var beatmaps = JsonConvert.DeserializeObject<List<Beatmap>>(resp, DateTimeConverter);
                return beatmaps;
        }

        /// <summary>
        /// Retrieves beatmap information for the specified user.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="api_key">Your osu! API key.</param>
        /// <param name="autoconverts">Whether to show autoconverts or not.</param>
        /// <param name="limit">Maximum number of results. Range: 0-500</param>
        /// <param name="mode">Map gamemode.</param>
        /// <returns>Returns a list of Beatmap obejcts.</returns>
        public static List<Beatmap> GetBeatmapsFromUser(string username, string api_key, int? mode = null, bool? autoconverts = null, int limit = 500)
        {
            var parameters = "";
            if (mode != null) parameters += $"&m={mode}";
            if (autoconverts != null) parameters += $"&a={Convert.ToInt32(autoconverts)}";
            if (limit != 500) parameters += $"&limit={limit}";
            var resp =
                        new System.Net.WebClient().DownloadString(
                            $"https://osu.ppy.sh/api/get_beatmaps?k={api_key}&u={username}&type=string"+parameters);
                var beatmaps = JsonConvert.DeserializeObject<List<Beatmap>>(resp, DateTimeConverter);
                return beatmaps;
        }

        /// <summary>
        /// Retrieves beatmap information for the specified user.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="api_key">Your osu! API key.</param>
        /// <param name="autoconverts">Whether to show autoconverts or not.</param>
        /// <param name="limit">Maximum number of results. Range: 0-500</param>
        /// <param name="mode">Map gamemode.</param>
        /// <returns>Returns a list of Beatmap obejcts.</returns>
        public static async Task<List<Beatmap>> GetBeatmapFromUserAsync(string username, string api_key, int? mode = null, bool? autoconverts = null, int limit = 500)
        {
            var parameters = "";
            if (mode != null) parameters += $"&m={mode}";
            if (autoconverts != null) parameters += $"&a={Convert.ToInt32(autoconverts)}";
            if (limit != 500) parameters += $"&limit={limit}";
            var resp =
                        await new System.Net.Http.HttpClient().GetStringAsync(
                            $"https://osu.ppy.sh/api/get_beatmaps?k={api_key}&u={username}&type=string"+parameters);
                var beatmaps = JsonConvert.DeserializeObject<List<Beatmap>>(resp, DateTimeConverter);
                return beatmaps;
        }

        /// <summary>
        /// Retrieves beatmap information for the specified user.
        /// </summary>
        /// <param name="user">User object.</param>
        /// <param name="api_key">Your osu! API key.</param>
        /// <param name="autoconverts">Whether to show autoconverts or not.</param>
        /// <param name="limit">Maximum number of results. Range: 0-500</param>
        /// <param name="mode">Map gamemode.</param>
        /// <returns>Returns a list of Beatmap obejcts.</returns>
        public static List<Beatmap> GetBeatmapsFromUser(User user, string api_key, int? mode = null, bool? autoconverts = null, int limit = 500)
        {
            var parameters = "";
            if (mode != null) parameters += $"&m={mode}";
            if (autoconverts != null) parameters += $"&a={Convert.ToInt32(autoconverts)}";
            if (limit != 500) parameters += $"&limit={limit}";
            var resp =
                        new System.Net.WebClient().DownloadString(
                            $"https://osu.ppy.sh/api/get_beatmaps?k={api_key}&u={user.UserId}&type=id" + parameters);
                var beatmaps = JsonConvert.DeserializeObject<List<Beatmap>>(resp, DateTimeConverter);
                return beatmaps;
        }

        /// <summary>
        /// Retrieves beatmap information for the specified user.
        /// </summary>
        /// <param name="user">User object.</param>
        /// <param name="api_key">Your osu! API key.</param>
        /// <param name="autoconverts">Whether to show autoconverts or not.</param>
        /// <param name="limit">Maximum number of results. Range: 0-500</param>
        /// <param name="mode">Map gamemode.</param>
        /// <returns>Returns a list of Beatmap obejcts.</returns>
        public static async Task<List<Beatmap>> GetBeatmapFromUserAsync(User user, string api_key, int? mode = null, bool? autoconverts = null, int limit = 500)
        {
            var parameters = "";
            if (mode != null) parameters += $"&m={mode}";
            if (autoconverts != null) parameters += $"&a={Convert.ToInt32(autoconverts)}";
            if (limit != 500) parameters += $"&limit={limit}";
            var resp =
                        await new System.Net.Http.HttpClient().GetStringAsync(
                            $"https://osu.ppy.sh/api/get_beatmaps?k={api_key}&u={user.UserId}&type=id"+parameters);
                var beatmaps = JsonConvert.DeserializeObject<List<Beatmap>>(resp, DateTimeConverter);
                return beatmaps;
        }

        /// <summary>
        /// Retrieves ranked beatmap information since the specified date.
        /// </summary>
        /// <param name="time">Date since when beatmaps should be returned.</param>
        /// <param name="api_key">Your osu! API key.</param>
        /// <param name="autoconverts">Whether to show autoconverts or not.</param>
        /// <param name="limit">Maximum number of results. Range: 0-500</param>
        /// <param name="mode">Map gamemode.</param>
        /// <returns>Returns a list of Beatmap obejcts.</returns>
        public static List<Beatmap> GetRankedBeatmapsSince(DateTime time, string api_key, int? mode = null, bool? autoconverts = null, int limit = 500)
        {
            var parameters = "";
            if (mode != null) parameters += $"&m={mode}";
            if (autoconverts != null) parameters += $"&a={Convert.ToInt32(autoconverts)}";
            if (limit != 500) parameters += $"&limit={limit}";
            var resp =
                        new System.Net.WebClient().DownloadString(
                            $"https://osu.ppy.sh/api/get_beatmaps?k={api_key}&since={time.ToString("yyyy - MM - dd HH: mm:ss")}"+parameters);
                var beatmaps = JsonConvert.DeserializeObject<List<Beatmap>>(resp, DateTimeConverter);
                return beatmaps;
        }

        /// <summary>
        /// Retrieves ranked beatmap information since the specified date.
        /// </summary>
        /// <param name="time">Date since when beatmaps should be returned.</param>
        /// <param name="api_key">Your osu! API key.</param>
        /// <param name="autoconverts">Whether to show autoconverts or not.</param>
        /// <param name="limit">Maximum number of results. Range: 0-500</param>
        /// <param name="mode">Map gamemode.</param>
        /// <returns>Returns a list of Beatmap obejcts.</returns>
        public static async Task<List<Beatmap>> GetRankedBeatmapsSinceAsync(DateTime time, string api_key, int? mode = null, bool? autoconverts = null, int limit = 500)
        {
            var parameters = "";
            if (mode != null) parameters += $"&m={mode}";
            if (autoconverts != null) parameters += $"&a={Convert.ToInt32(autoconverts)}";
            if (limit != 500) parameters += $"&limit={limit}";
            var resp =
                        await new System.Net.Http.HttpClient().GetStringAsync(
                            $"https://osu.ppy.sh/api/get_beatmaps?k={api_key}&since={time.ToString("yyyy - MM - dd HH: mm:ss")}"+parameters);
                var beatmaps = JsonConvert.DeserializeObject<List<Beatmap>>(resp, DateTimeConverter);
                return beatmaps;
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
                        $"https://osu.ppy.sh/api/get_scores?b={beatmap_id}&k={api_key}"+parameters);
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
                        $"https://osu.ppy.sh/api/get_scores?b={beatmap_id}&k={api_key}"+parameters);
                var scores = JsonConvert.DeserializeObject<List<Score>>(resp, DateTimeConverter);
                return scores;
        }

        #endregion

        #region /get_user_best

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
                    $"https://osu.ppy.sh/api/get_user_best?u={user_id}&k={api_key}&type=id"+parameters);
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
                        $"https://osu.ppy.sh/api/get_user_best?u={user_id}&k={api_key}&type=id"+parameters);
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
                    $"https://osu.ppy.sh/api/get_user_best?u={username}&k={api_key}&type=string"+parameters);
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
                        $"https://osu.ppy.sh/api/get_user_best?u={username}&k={api_key}&type=string"+parameters);
                var scores = JsonConvert.DeserializeObject<List<UserScore>>(resp, DateTimeConverter);
                return scores;
        }


        #endregion

        #region /get_user_recent
        /// <summary>
        /// Retrieves the top scores for a player. Defaults to 10.
        /// </summary>
        /// <param name="api_key">API key.</param>
        /// <param name="username">Username.</param>
        /// <param name="mode">Gamemode to retrieve scores from.</param>
        /// <param name="limit">Limit (range: 1-100)</param>
        /// <returns>Returns a list of Score objects.</returns>
        public static List<UserScore> GetUserRecentPlaysByUsername(string api_key, string username, int? mode = null, int limit = 10)
        {
            var parameters = "";
            if (mode != null) parameters += $"&m={mode}";
            if (limit != 10) parameters += $"&limit={limit}";
            var resp =
                    new System.Net.WebClient().DownloadString(
                    $"https://osu.ppy.sh/api/get_user_recent?u={username}&k={api_key}&type=string"+parameters);
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
        public static async Task<List<UserScore>> GetUserRecentPlaysByUsernameAsync(string api_key, string username, int? mode = null, int limit = 10)
        {
            var parameters = "";
            if (mode != null) parameters += $"&m={mode}";
            if (limit != 10) parameters += $"&limit={limit}";
            var resp =
                    await new System.Net.Http.HttpClient().GetStringAsync(
                    $"https://osu.ppy.sh/api/get_user_recent?u={username}&k={api_key}&type=string"+parameters);
                var scores = JsonConvert.DeserializeObject<List<UserScore>>(resp, DateTimeConverter);
                return scores;
        }

        /// <summary>
        /// Retrieves the recent plays for a user.
        /// </summary>
        /// <param name="api_key">API key.</param>
        /// <param name="user_id">User ID.</param>
        /// <param name="mode">Gamemode to retrieve scores from.</param>
        /// <param name="limit">Limit (range: 1-100)</param>
        /// <returns>Returns a list of Score objects.</returns>
        public static List<UserPlay> GetUserRecentPlaysByUserID(string api_key, int user_id, int? mode = null, int limit = 10)
        {
            var parameters = "";
            if (mode != null) parameters += $"&m={mode}";
            if (limit != 10) parameters += $"&limit={limit}";
            var resp =
                    new System.Net.WebClient().DownloadString(
                    $"https://osu.ppy.sh/api/get_user_recent?u={user_id}&k={api_key}&type=id"+parameters);
                var scores = JsonConvert.DeserializeObject<List<UserPlay>>(resp, DateTimeConverter);
                return scores;
        }

        /// <summary>
        /// Retrieves the recent plays for a user.
        /// </summary>
        /// <param name="api_key">API key.</param>
        /// <param name="user_id">User ID.</param>
        /// <param name="mode">Gamemode to retrieve scores from.</param>
        /// <param name="limit">Limit (range: 1-100)</param>
        /// <returns>Returns a list of Score objects.</returns>
        public static async Task<List<UserPlay>> GetUserRecentPlaysByUserIDAsync(string api_key, int user_id, int? mode = null, int limit = 10)
        {
            var parameters = "";
            if (mode != null) parameters += $"&m={mode}";
            if (limit != 10) parameters += $"&limit={limit}";
            var resp =
                    await new System.Net.Http.HttpClient().GetStringAsync(
                    $"https://osu.ppy.sh/api/get_user_recent?u={user_id}&k={api_key}&type=id"+parameters);
                var scores = JsonConvert.DeserializeObject<List<UserPlay>>(resp, DateTimeConverter);
                return scores;
        }

        #endregion

        #region /get_match

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

        #endregion
    }
    
}
