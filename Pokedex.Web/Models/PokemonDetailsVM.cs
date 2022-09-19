using System.ComponentModel.DataAnnotations;

namespace Pokedex.Web.Models
{
    public class PokemonDetailsVM
    {
        public int Id { get; set; }

        [Display(Name = "Nacional Pokédex Number")]
        public string NacionalPokedexNumber { get; set; }
        public string Name { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Category { get; set; }
        public string Abilities { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}
