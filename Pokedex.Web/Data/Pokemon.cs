
namespace Pokedex.Web.Data
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string NacionalPokedexNumber { get; set; }
        public string Name { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Category { get; set; }
        public string Abilities { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
