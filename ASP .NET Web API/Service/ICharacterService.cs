using ASP_.NET_Web_API.Model;
using ASP_.NET_Web_API.Model.Dtos;

namespace ASP_.NET_Web_API.Service
{
    public interface ICharacterService
    {
        Task<List<CharacterResponse>> GetAllCharactersAsync();
        Task<CharacterResponse?> GetCharacterByIdAsync(int id);
        Task<CharacterResponse> AddCharacterAsync(AddCharacterRequest character);
        Task<bool> DeleteCharacterAsync(int id);
        Task<bool> UpdateCharacterAsync(int id, UpdateCharacterRequest character);

    }
}
