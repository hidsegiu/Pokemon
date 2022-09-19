using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Pokedex.Web.Models
{
    public class PokemonIndexVM
    {
        public int Id { get; set; }

        [Display(Name = "#")]
        public string NacionalPokedexNumber { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
