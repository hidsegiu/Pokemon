using Pokedex.Web.Data;
using Pokedex.Web.Models;

namespace Pokedex.Web.Contracts
{
    public interface IPokemonRepository : IGenericRepository<Pokemon>
    {
        Task<bool> SetOrEditImage(PokemonCreateVM pokemonVM, string webRoot, IFormFileCollection formFiles);
    }
}
