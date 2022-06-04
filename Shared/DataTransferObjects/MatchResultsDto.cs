using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class MatchResultsDto
    {
        public int MatchId { get; set; }
        public HamsterDto? WinningHamster { get; set; }
        public HamsterDto? LosingHamster { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
