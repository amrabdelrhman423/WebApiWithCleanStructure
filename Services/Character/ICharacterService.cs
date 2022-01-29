using System.Collections.Generic;
using testapi.Models;
using System.Threading.Tasks;
using testapi.DTOs.Character;

namespace testapi.ServicesCharacter

{
    public interface ICharacterService
    {
       Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();
       Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto character);
        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter);
        Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id);
    }
}
