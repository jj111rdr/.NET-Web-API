using ASP_.NET_Web_API.Model;

namespace ASP_.NET_Web_API.Service
{
    public class CharacterService : ICharacterService
    {
        static List<Character> _characters = new List<Character>
            {
                new Character { Id = 1, Name = "Mario", Game = "Super Mario Bros.", CharacterRole = "Protagonist" },
                new Character { Id = 2, Name = "Link", Game = "The Legend of Zelda", CharacterRole = "Protagonist" },
                new Character { Id = 3, Name = "Samus Aran", Game = "Metroid", CharacterRole = "Antagonist" },
                new Character { Id = 4, Name = "Arthur Morgan", Game = "Red Dead Redemption", CharacterRole = "Protagonist" }
            };
        public Task<Character> AddCharacterAsync(Character character)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCharacterAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Character>> GetAllCharactersAsync() =>
            await Task.FromResult(_characters);

        public async Task<Character?> GetCharacterByIdAsync(int id)
        {
            var result = _characters.FirstOrDefault(c => c.Id == id);
            return await Task.FromResult(result);
        }

        public Task<bool> UpdateCharacterAsync(int id, Character character)
        {
            throw new NotImplementedException();
        }
    }
}
