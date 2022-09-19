using Pokedex.Web.Data;
using System.ComponentModel.DataAnnotations;

namespace Pokedex.Web.Models
{
    public class PokemonCreateVM
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nacional Pokédex Number")]
        public string NacionalPokedexNumber { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Height { get; set; }

        [Required]
        public string Weight { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Abilities { get; set; }

        [Required]
        public string Description { get; set; }

        [Display(Name = "Image")]
        public string? ImageUrl { get; set; }
    }
}
