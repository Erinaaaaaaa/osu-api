using Newtonsoft.Json;
using osu_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osu_api
{
    public partial class OsuApi
    {        

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
                            $"https://osu.ppy.sh/api/get_beatmaps?k={api_key}&u={user_id}&type=id" + parameters);
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
                            $"https://osu.ppy.sh/api/get_beatmaps?k={api_key}&u={username}&type=string" + parameters);
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
                            $"https://osu.ppy.sh/api/get_beatmaps?k={api_key}&u={username}&type=string" + parameters);
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
                            $"https://osu.ppy.sh/api/get_beatmaps?k={api_key}&u={user.UserId}&type=id" + parameters);
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
                            $"https://osu.ppy.sh/api/get_beatmaps?k={api_key}&since={time.ToString("yyyy - MM - dd HH: mm:ss")}" + parameters);
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
                            $"https://osu.ppy.sh/api/get_beatmaps?k={api_key}&since={time.ToString("yyyy - MM - dd HH: mm:ss")}" + parameters);
            var beatmaps = JsonConvert.DeserializeObject<List<Beatmap>>(resp, DateTimeConverter);
            return beatmaps;
        }


    }
}
