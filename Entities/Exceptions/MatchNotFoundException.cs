using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class MatchNotFoundException : NotFoundException
    {
        public MatchNotFoundException(int id) : base($"Match with id {id} was not found")
        { }
    }
}
