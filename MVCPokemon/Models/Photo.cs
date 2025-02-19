namespace MVCPokemon.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Author { get; set; }

        public string? ImageUrl { get; set; } 
    }
}
