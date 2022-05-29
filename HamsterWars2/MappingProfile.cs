using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamsterWars2
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Hamster, HamsterDto>();

            CreateMap<CreateHamsterDto, Hamster>(); 

            CreateMap<MatchData, MatchDataDto>();
            
            CreateMap<MatchDataDto, MatchData>();

            CreateMap<UpdateHamsterDto, Hamster>();

            CreateMap<UserRegistrationDto, User>();
        }
    }
}
