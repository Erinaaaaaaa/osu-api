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
    }
}
