using System;
using System.Collections.Generic;

namespace MFLReskin.Models
{
    public class Player
    {
        public Player()
        {
        }

        public Player(Dictionary<string, string> data)
        {
            if (int.TryParse(data["id"], out int id))
            {
                Id = id;
            }
            Name = data["name"];
            Team = data["team"];
            Position = data["position"];
            if (int.TryParse(data["statsGlobalId"], out int statsGlobalId))
            {
                StatsGlobalId = statsGlobalId;
            }
            if (int.TryParse(data["statsId"], out int statsId))
            {
                StatsId = statsId;
            }
            if (Guid.TryParse(data["sportsDataId"], out Guid sportsDataId))
            {
                SportsDataId = sportsDataId;
            }
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Team { get; set; }
        public string Position { get; set; }
        public int? StatsGlobalId { get; set; }
        public int? StatsId { get; set; }
        public Guid? SportsDataId { get; set; }
        public string Status { get; set; }
    }
}
