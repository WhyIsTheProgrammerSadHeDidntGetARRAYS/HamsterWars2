using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class UpdateHamsterDto
    {
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public int Age { get; set; }
        public string? Loves { get; set; }
        public string? FavoriteFood { get; set; }
        public int TotalGames { get; set; }
        public int Wins { get; set; }
        public int Defeats { get; set; }
    }
}
