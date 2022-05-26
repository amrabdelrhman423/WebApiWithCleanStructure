using AutoMapper;
using Microsoft.EntityFrameworkCore;
using testapi.Data;
using testapi.DTOs.Character;
using testapi.Models;
using testapi.ServicesCharacter;

namespace testapi.Properties.ServicesCharacter
{
    public class CharacterService : ICharacterService
    {
      

        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public CharacterService( IMapper mapper ,DataContext context )
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto character)
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

            Character characterAdded = _mapper.Map<Character>(character);
            await _context.characters.AddAsync(characterAdded);
            await _context.SaveChangesAsync();
  
            serviceResponse.Data = (_context.characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

            try
            {
               
                Character character = await _context.characters.FirstAsync(c => c.Id == id);

                _context.characters.Remove   (character);
                await _context.SaveChangesAsync ();
                serviceResponse.Data = (_context.characters.Select(c=>_mapper.Map<GetCharacterDto>(c))).ToList();
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
            List<Character> dbCharacters = await _context.characters.ToListAsync();
            serviceResponse.Data= (dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            return serviceResponse ;
        }

        public async Task <ServiceResponse<GetCharacterDto> > GetCharacterById(int id)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
            Character character = await _context.characters.FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.Data=_mapper.Map<GetCharacterDto>(character);
            return serviceResponse;

        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();

            try { 
         Character character = new Character();
            character.Name = updateCharacter.Name;
            character.Class = updateCharacter.Class;
            character.Defense = updateCharacter.Defense;
            character.HitPoints = updateCharacter.HitPoints;
            character.Intelligence= updateCharacter.Intelligence;
            character.Strength = updateCharacter.Strength;
                _context.characters.Update(character);

                await _context.SaveChangesAsync();

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
