using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class MatchCompleted
    {
        public HamsterDto? HamsterCompetitor { get; set; }
        public bool MatchWon { get; set; }
    }
}
