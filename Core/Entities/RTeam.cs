using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class RTeam
    {
        public int RTeamId { get; set; }
        public int RLeagueId { get; set; }
        public string TeamName { get; set; }
        public bool? FCheck { get; set; }

        public RLeague RLeague { get; set; }
    }
}
