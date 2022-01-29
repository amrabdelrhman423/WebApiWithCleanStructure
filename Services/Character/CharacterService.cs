using AutoMapper;
using testapi.DTOs.Character;
using testapi.Models;
using testapi.ServicesCharacter;

namespace testapi.Properties.ServicesCharacter
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> Characters = new List<Character>
        {
            new Character(),
            new Character{Id=1,Name="Ahmed"},
            new Character{Id=2, Name="Ali"},
            new Character{Id=3, Name ="Medo"}

        };

        private readonly IMapper _mapper;
        public CharacterService( IMapper mapper   )
        {
            _mapper = mapper;   
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto character)
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            Character characterAdded = _mapper.Map<Character>(character);
            characterAdded.Id=Characters.Max(character=>character.Id)+1;
            Characters.Add(characterAdded);
  
            serviceResponse.Data = (Characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

            try
            {
                Character character = Characters.First(c => c.Id == id);
                Characters.Remove   (character);
                serviceResponse.Data = (Characters.Select(c=>_mapper.Map<GetCharacterDto>(c))).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            serviceResponse.Data= (Characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            return serviceResponse ;
        }

        public async Task <ServiceResponse<GetCharacterDto> > GetCharacterById(int id)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
            serviceResponse.Data=_mapper.Map<GetCharacterDto>(Characters.FirstOrDefault(c => c.Id == id));
            return serviceResponse;

        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();

            try { 
         Character character=  Characters.FirstOrDefault(c => c.Id == updateCharacter.Id);
            character.Name = updateCharacter.Name;
            character.Class = updateCharacter.Class;
            character.Defense = updateCharacter.Defense;
            character.HitPoints = updateCharacter.HitPoints;
            character.Intelligence= updateCharacter.Intelligence;
            character.Strength = updateCharacter.Strength;

            serviceResponse.Data=_mapper.Map<GetCharacterDto>(character);
            }
            catch (Exception ex) {
                serviceResponse.Success = false;
                serviceResponse.Message=ex.Message;
            }
            return serviceResponse;

        }
    }
}
