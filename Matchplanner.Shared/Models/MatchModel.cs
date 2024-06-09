using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matchplanner.Shared.Models
{
    public class MatchModel
    {

        public int Id { get; set; }
        public int HomeId { get; set; }
        public int AwayId { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }

    }
}
