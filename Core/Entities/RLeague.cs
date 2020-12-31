using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class RLeague
    {
        public RLeague()
        {
            RTeam = new HashSet<RTeam>();
        }

        public int RLeagueId { get; set; }
        public string Code { get; set; }
        public string LeagueName { get; set; }
        public string Country { get; set; }
        public bool? FCheck { get; set; }

        public ICollection<RTeam> RTeam { get; set; }
    }
}
