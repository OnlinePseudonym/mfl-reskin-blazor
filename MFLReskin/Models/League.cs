using System.Collections.Generic;

namespace MFLReskin.Models
{
    public class League
    {
        public string FranchiseId { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string FranchiseName { get; set; }
        public int LeagueId { get; set; }
        public List<Player> MyRoster { get; set; }
    }
}
