using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pokedex.Web.Contracts;
using Pokedex.Web.Data;
using Pokedex.Web.Models;

namespace Pokedex.Web.Controllers
{
    public class PokemonsController : Controller
    {
        private readonly IPokemonRepository pokemonRepository;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment hostEnvironment;

        public PokemonsController(IPokemonRepository pokemonRepository, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            this.pokemonRepository = pokemonRepository;
            this.mapper = mapper;
            this.hostEnvironment = hostEnvironment;
        }

        // GET: Pokemons
        public async Task<IActionResult> Index()
        {
            var pokemon = await pokemonRepository.GetAllAsync();
            var pokemonVM = mapper.Map<List<PokemonIndexVM>>(pokemon);
            return View(pokemonVM);
        }

        // GET: Pokemons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var pokemon = await pokemonRepository.GetAsync(id);

            if (pokemon == null)
            {
                return NotFound();
            }

            var pokemonVM = mapper.Map<PokemonDetailsVM>(pokemon);

            return View(pokemonVM);
        }

        // GET: Pokemons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pokemons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PokemonCreateVM pokemonVM)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = hostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                await pokemonRepository.SetOrEditImage(pokemonVM, webRootPath, files);

                var pokemon = mapper.Map<Pokemon>(pokemonVM);
                await pokemonRepository.AddAsync(pokemon);
                return RedirectToAction(nameof(Index));
            }
            return View(pokemonVM);
        }

        // GET: Pokemons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var pokemon = await pokemonRepository.GetAsync(id);

            if (pokemon == null)
            {
                return NotFound();
            }

            var pokemonVM = mapper.Map<PokemonCreateVM>(pokemon);
            return View(pokemonVM);
        }

        // POST: Pokemons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PokemonCreateVM pokemonVM)
        {
            if (id != pokemonVM.Id)
            {
                return NotFound();
            }

            var pokemon = await pokemonRepository.GetAsync(id);
            pokemonVM.ImageUrl = pokemon.ImageUrl;

            if (pokemon == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string webRootPath = hostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                await pokemonRepository.SetOrEditImage(pokemonVM, webRootPath, files);

                try
                {
                    mapper.Map(pokemonVM, pokemon);
                    await pokemonRepository.UpdateAsync(pokemon);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await pokemonRepository.Exists(pokemonVM.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pokemonVM);
        }

        // POST: Pokemons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await pokemonRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

