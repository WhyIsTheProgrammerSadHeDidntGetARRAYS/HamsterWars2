using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class MatchHistoryDto
    {
        public int MatchId { get; set; }
        public HamsterDto? WinningHamster { get; set; }
        public HamsterDto? LosingHamster { get; set; }
    }
}
