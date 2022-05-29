using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class MatchDataDto //TODO: Behöver en creatematch dto också, och den ska se ut såhär. Matchdatadto behöver nog ha id parameter också
    {
        public int WinnerId { get; set; }
        public int LoserId { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
