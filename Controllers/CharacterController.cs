using Microsoft.AspNetCore.Mvc;
using testapi.DTOs.Character;
using testapi.Models;
using testapi.ServicesCharacter;

namespace testapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController :ControllerBase
    {

        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService characterService)
        {
            _characterService=characterService;
        }
       

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get() {
            return Ok(await _characterService.GetAllCharacters());
                }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddCharater(AddCharacterDto character)
        {
            return Ok(await _characterService.AddCharacter(character));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCharacter(UpdateCharacterDto Updatecharacter)
        {

            ServiceResponse<GetCharacterDto> response= await _characterService.UpdateCharacter(Updatecharacter);
            if(response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            ServiceResponse<List<GetCharacterDto>> response = await _characterService.DeleteCharacter(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
