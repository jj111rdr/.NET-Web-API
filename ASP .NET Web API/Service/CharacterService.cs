using ASP_.NET_Web_API.Data;
using ASP_.NET_Web_API.Model;
using Microsoft.EntityFrameworkCore;

namespace ASP_.NET_Web_API.Service
{
    public class CharacterService(AppDbContext context) : ICharacterService
    {
        public Task<Character> AddCharacterAsync(Character character)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCharacterAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Character>> GetAllCharactersAsync() =>
            await context.Characters.ToListAsync();

        public async Task<Character?> GetCharacterByIdAsync(int id)
        {
            var result = await context.Characters.FindAsync(id);
            return result;
        }

        public Task<bool> UpdateCharacterAsync(int id, Character character)
        {
            throw new NotImplementedException();
        }
    }
}
