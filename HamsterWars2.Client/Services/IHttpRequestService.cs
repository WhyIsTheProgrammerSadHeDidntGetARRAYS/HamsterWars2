using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamsterWars2.Client.Services
{
    public interface IHttpRequestService
    {
        Task<IEnumerable<HamsterDto>> GetHamstersAsync();
        Task<HamsterDto> GetRandomHamsterAsync();
    }
}
