using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    // this dto is used to display only the neccessary properties when showing hamster stats to the client
    public class HamsterStatsDto
    {
        public int Id { get; init; }
        public string? Name { get; init; }
        public string? ImageUrl { get; init; }
        public int TotalGames { get; init; }
        public int Wins { get; init; }
        public int Losses { get; init; }
    }
}
