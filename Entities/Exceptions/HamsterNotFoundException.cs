using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class HamsterNotFoundException : NotFoundException
    {
        public HamsterNotFoundException(int id) : base($"Hamster with id {id} was not found")
        { }
    }
}
