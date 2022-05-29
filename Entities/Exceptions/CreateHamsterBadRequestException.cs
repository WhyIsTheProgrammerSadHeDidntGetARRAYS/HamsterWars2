using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class CreateHamsterBadRequestException : BadRequestException
    {
        public CreateHamsterBadRequestException() : base("Bad request from client when trying to add new hamster")
        { }
    }
}
