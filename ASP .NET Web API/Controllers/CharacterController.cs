using ASP_.NET_Web_API.Model;
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
        public async Task<ActionResult<List<Character>>> GetCharacters() =>
            Ok(await characterService.GetAllCharactersAsync());

        [Route("GetCharacterById/{id}")]
        [HttpGet]
        public async Task<ActionResult<Character?>> GetCharacterById(int id)
        {
            var character = await characterService.GetCharacterByIdAsync(id);
            if(character is null)
            {
                return NotFound($"Character with Id {id} does not exist");
            }
            return Ok(character);
        }

    }
}
