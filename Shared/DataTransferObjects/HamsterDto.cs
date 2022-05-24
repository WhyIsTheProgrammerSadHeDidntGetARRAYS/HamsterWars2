using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class HamsterDto
    {
        public int Id { get; init; }
        public string? Name { get; init; }
        public string? ImageUrl { get; init; }
        public int Likes { get; init; }
        public int Age { get; init; }
        public string? Loves { get; init; }
        public string? FavoriteFood { get; init; }
        public int TotalGames { get; set; }
        public int Wins { get; set; }
        public int Defeats { get; set; }
    }
}
