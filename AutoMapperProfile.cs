using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using code_net.DataTransferObjects.Character;
using code_net.Models;

namespace code_net
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDTO>();
            CreateMap<AddCharacterDTO, Character>();
            CreateMap<AddCharacterDTO, GetCharacterDTO>();
        }
    }
}