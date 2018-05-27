using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osu_api.Models.UserEvents
{
    public class MapScoreEvent : Event
    {
        public string MapScoreGrade;
        public uint MapRank;
    }
}