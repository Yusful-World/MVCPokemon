using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MVCPokemon.Data;
using MVCPokemon.Models;
using System.ComponentModel;
using static System.Net.Mime.MediaTypeNames;

namespace MVCPokemon.Controllers
{
    
    public class PokemonController : Controller
    {
        private readonly ImageService _imageService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly PokemonDbContext _context;
        public PokemonController(IWebHostEnvironment webHostEnvironment, PokemonDbContext context, ImageService imageService)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
            _imageService = imageService; 
        }
        public IActionResult Pokemons()
        {
            var pokemons = _context.Pokemons.ToList();
            return View(pokemons);
        }

        public IActionResult AddPokemon()
        {
            return View(new Pokemon());
        }

        [HttpPost]
        public async Task<IActionResult> AddPokemon(Pokemon pokemon, [FromForm] IFormFile? image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (image != null && image.Length > 0)
                    {
                        string validateImage = _imageService.ValidateImage(image);
                        if (!string.IsNullOrEmpty(validateImage))
                        {
                            TempData["error"] = validateImage;
                            return View(pokemon);
                        }

                        string imageUrl = await _imageService.SaveImageAsync(image);

                        pokemon.ImageUrl = imageUrl;
                    }
                    
                    await _context.Pokemons.AddAsync(pokemon);
                    await _context.SaveChangesAsync();

                    TempData["success"] = "Pokemon added successfully.";
                    return RedirectToAction("Pokemons");
                }
                catch(Exception)
                {
                    TempData["error"] = "An error occurred while adding pokemon. Please try again";
                    return View(pokemon);
                }
                
            }
            return View(pokemon);
        }

        public IActionResult UpdatePokemon(int? id)
        {
            
            if (id == 0 || id == null)
            {
                return NotFound(id);
            }

            var pokemonFromDb = _context.Pokemons.FirstOrDefault(p => p.Id == id);
            if (pokemonFromDb == null)
            {
                return NotFound(pokemonFromDb);
            }

            return View(pokemonFromDb);

        }

        [HttpPost]
        public async Task<IActionResult> UpdatePokemon(Pokemon pokemon, [FromForm] IFormFile? newImage)
        {
            if (ModelState.IsValid)
            {
                if (newImage != null)
                {
                    _imageService.ValidateImage(newImage);

                    var oldImage = pokemon.ImageUrl;

                    if (!string.IsNullOrEmpty(oldImage))
                    {
                        _imageService.DeleteImage(oldImage);
                    }

                    var savedImage = await _imageService.SaveImageAsync(newImage);

                    pokemon.ImageUrl = savedImage;
                }

                _context.Pokemons.Update(pokemon);
                await _context.SaveChangesAsync();
                TempData["success"] = "Pokemon updated successfully.";

                return RedirectToAction("Pokemons");
            }
            else
            {
                TempData["error"] = "An error occured while updating pokemon.";
            }



            return View();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePokemon(int id)
        {
            if (id == 0 || id == null)
            {
                TempData["Error"] = "Invalid Pokémon ID.";
                return Json(new { success = false });
            }

            var pokemonFromDb = _context.Pokemons.FirstOrDefault(p => p.Id == id);

            if (pokemonFromDb != null)
            {
                _imageService.DeleteImage(pokemonFromDb.ImageUrl);
                _context.Pokemons.Remove(pokemonFromDb);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Pokémon deleted successfully!";

                return Json(new { success = true, id });
            }

            return View();
        }


    }
}
