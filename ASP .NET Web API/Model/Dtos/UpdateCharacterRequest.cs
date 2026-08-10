namespace ASP_.NET_Web_API.Model.Dtos
{
    public class UpdateCharacterRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Game { get; set; } = String.Empty;
        public string CharacterRole { get; set; } = String.Empty;
    }
}
