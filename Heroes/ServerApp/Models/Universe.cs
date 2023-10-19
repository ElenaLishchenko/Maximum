namespace ServerApp.Models
{
    public class Universe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Superhero> Superheroes { get; set; } = new();
    }
}
