using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class CreateHamsterDto
    {
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public int Age { get; set; }
        public string? Loves { get; set; }
        public string? FavoriteFood { get; set; }
    }
}
