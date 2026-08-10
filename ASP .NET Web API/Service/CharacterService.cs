using ASP_.NET_Web_API.Data;
using ASP_.NET_Web_API.Model;
using ASP_.NET_Web_API.Model.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ASP_.NET_Web_API.Service
{
    public class CharacterService(AppDbContext context) : ICharacterService
    {
        public async Task<CharacterResponse> AddCharacterAsync(AddCharacterRequest character)
        {
            var newCharacter = new Character()
            {
                Name = character.Name,
                Game = character.Game,
                CharacterRole = character.CharacterRole,
            };
            context.Characters.Add(newCharacter);
            await context.SaveChangesAsync();
            return new CharacterResponse 
            { 
                Id = newCharacter.Id,
                Name = character.Name, 
                Game = character.Game, 
                CharacterRole = character.CharacterRole 
            };
        }

        public async Task<bool> DeleteCharacterAsync(int id)
        {
            var character = await context.Characters.FindAsync(id);
            if (character is null)
            {
                return false;
            }

            context.Characters.Remove(character);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<CharacterResponse>> GetAllCharactersAsync() =>
            await context.Characters.Select(c=> new CharacterResponse
            {
                Id = c.Id,
                Name = c.Name,
                Game = c.Game,
                CharacterRole = c.CharacterRole,
            }).ToListAsync();

        public async Task<CharacterResponse?> GetCharacterByIdAsync(int id)
        {
            var result = await context.Characters.Where(c => c.Id == id).Select(c => new CharacterResponse
            {
                Id = c.Id,
                Name = c.Name,
                Game = c.Game,
                CharacterRole = c.CharacterRole,
            }).FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> UpdateCharacterAsync(int id, UpdateCharacterRequest character)
        {
            var existingCharacter = await context.Characters.FindAsync(id);
            if (existingCharacter is null)
            {
                return false;
            }

            existingCharacter.Name = character.Name;
            existingCharacter.Game = character.Game;
            existingCharacter.CharacterRole = character.CharacterRole;

            await context.SaveChangesAsync();
            return true;
        }
    }
}
