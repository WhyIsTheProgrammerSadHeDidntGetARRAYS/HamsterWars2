using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class CreateMatchBadRequestException : BadRequestException
    {
        public CreateMatchBadRequestException() : base("Bad request from client, when trying to add match data")
        { }
    }
}
