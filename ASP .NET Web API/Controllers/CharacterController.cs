using ASP_.NET_Web_API.Model;
using ASP_.NET_Web_API.Model.Dtos;
using ASP_.NET_Web_API.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_.NET_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController(ICharacterService characterService) : ControllerBase
    {

        [Route("GetCharacters")]
        [HttpGet]
        public async Task<ActionResult<List<CharacterResponse>>> GetCharacters() =>
            Ok(await characterService.GetAllCharactersAsync());

        [Route("GetCharacterById/{id}")]
        [HttpGet]
        public async Task<ActionResult<CharacterResponse?>> GetCharacterById(int id)
        {
            var character = await characterService.GetCharacterByIdAsync(id);
            if(character is null)
            {
                return NotFound($"Character with Id {id} does not exist.");
            }
            return Ok(character);
        }
        [HttpPost]
        public async Task<ActionResult<CharacterResponse>> AddCharacter(AddCharacterRequest request)
        {
            var newCharacter = await characterService.AddCharacterAsync(request);
            return CreatedAtAction(nameof(GetCharacterById), new { id = newCharacter.Id }, newCharacter);
        }
        [HttpPut("UpdateCharacter/{id}")]
        public async Task<ActionResult> UpdateCharacter(int id, UpdateCharacterRequest request)
        {
            var updated = await characterService.UpdateCharacterAsync(id, request);
            if (!updated)
            {
                return NotFound($"Character with Id {id} does not exist.");
            }
            return Ok($"Character with Id {id} updated successfully!");
        }
        [HttpDelete("DeleteCharacter/{id}")]
        public async Task<ActionResult> DeleteCharacter(int id)
        {
            var deleted = await characterService.DeleteCharacterAsync(id);
            if (!deleted)
            {
                return NotFound($"Character with Id {id} does not exist");
            }
            return Ok("Character deleted successfully!");
        }
    }
}
