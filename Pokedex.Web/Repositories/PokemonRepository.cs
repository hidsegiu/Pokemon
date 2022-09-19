using Pokedex.Web.Contracts;
using Pokedex.Web.Data;
using Pokedex.Web.Models;

namespace Pokedex.Web.Repositories
{
    public class PokemonRepository : GenericRepository<Pokemon>, IPokemonRepository
    {
        private readonly IGenericRepository<Pokemon> genericRepository;

        public PokemonRepository(ApplicationDbContext context, IGenericRepository<Pokemon> genericRepository) : base(context)
        {
            this.genericRepository = genericRepository;
        }

        public async Task<bool> SetOrEditImage(PokemonCreateVM pokemonVM, string webRoot, IFormFileCollection formFiles)
        {
            var webRootPath = webRoot;
            var files = formFiles;

            if (files.Count > 0)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"images\pokemons");
                var extenstion = Path.GetExtension(files[0].FileName);

                if (pokemonVM.ImageUrl != null)
                {
                    //This is an edit and we need to remove old image
                    var imagePath = Path.Combine(webRootPath, pokemonVM.ImageUrl.TrimStart('\\'));
                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                    }
                }
                using (var filesStreams = new FileStream(Path.Combine(uploads, fileName + extenstion), FileMode.Create))
                {
                    files[0].CopyTo(filesStreams);
                }
                pokemonVM.ImageUrl = @"\images\pokemons\" + fileName + extenstion;

                return true;
            }
            else
            {
                //Update when they do not change the image
                if (pokemonVM.Id != 0)
                {
                    Pokemon objFromDb = await genericRepository.GetAsync(pokemonVM.Id);
                    pokemonVM.ImageUrl = objFromDb.ImageUrl;
                }

                return false;
            }
        }
    }
}

