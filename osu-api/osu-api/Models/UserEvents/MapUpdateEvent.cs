using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osu_api.Models.UserEvents
{
    public class MapUpdateEvent : Event
    {
        public MapUpdateAction Action;

        public enum MapUpdateAction
        {
            Submit,
            Update,
            Revive,
            Delete
        }
    }
}
