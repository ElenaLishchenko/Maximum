namespace ServerApp.Models
{
    public class Superhero
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Power { get; set; }
        public int UniverseId { get; set; }
        public Universe Universe { get; set; }
    }
}
