using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matchplanner.Shared.Models;

    public class UserModel
    {
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }

    public required int TeamID {  get; set; }

    public string? ApiToken { get; set; }

    }

