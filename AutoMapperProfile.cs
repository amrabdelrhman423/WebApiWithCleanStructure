using AutoMapper;
using testapi.DTOs.Character;
using testapi.Models;

namespace testapi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character > ();
        }
    }
}
