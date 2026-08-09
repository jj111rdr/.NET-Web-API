using ASP_.NET_Web_API.Model;

namespace ASP_.NET_Web_API.Service
{
    public interface ICharacterService
    {
        Task<List<Character>> GetAllCharactersAsync();
        Task<Character?> GetCharacterByIdAsync(int id);
        Task<Character> AddCharacterAsync(Character character);
        Task<bool> DeleteCharacterAsync(int id);
        Task<bool> UpdateCharacterAsync(int id, Character character);

    }
}
