using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matchplanner.Shared.Models;

public class TeamModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int ClubId { get; set; }
}
