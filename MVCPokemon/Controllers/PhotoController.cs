using Microsoft.AspNetCore.Mvc;
using MVCPokemon.Data;
using MVCPokemon.Models;

namespace MVCPokemon.Controllers
{
    public class PhotoController : Controller
    {
        private readonly ImageService _imageService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly PokemonDbContext _context;
        public PhotoController(IWebHostEnvironment webHostEnvironment, PokemonDbContext context, ImageService imageService)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
            _imageService = imageService;
        }
        public IActionResult Photos()
        {
            var photos = _context.Photos.ToList();
            return View(photos);
        }

        public IActionResult Photo(int? id)
        {
            var photo = _context.Photos.FirstOrDefault(p => p.Id == id);
            if (photo == null)
            {
                TempData["error"] = "Invalid photo id";
                return NotFound();
            }

            return View(photo);
        }

        public IActionResult AddPhoto()
        {
            return View(new Photo());
        }

        [HttpPost]
        public async Task<IActionResult> AddPhoto(Photo photo, [FromForm] IFormFile? image)
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
                            return View(photo);
                        }

                        string imageUrl = await _imageService.SaveImageAsync(image);

                        photo.ImageUrl = imageUrl;
                    }

                    await _context.Photos.AddAsync(photo);
                    await _context.SaveChangesAsync();

                    TempData["success"] = "Photo added successfully.";
                    return RedirectToAction("Photos");
                }
                catch (Exception)
                {
                    TempData["error"] = "An error occurred while adding photo. Please try again";
                    return View(photo);
                }

            }
            return View(photo);
        }

        public IActionResult UpdatePhoto(int? id)
        {

            if (id == 0 || id == null)
            {
                return NotFound(id);
            }

            var photoFromDb = _context.Photos.FirstOrDefault(p => p.Id == id);
            if (photoFromDb == null)
            {
                return NotFound(photoFromDb);
            }

            return View(photoFromDb);

        }

        [HttpPost]
        public async Task<IActionResult> UpdatePokemon(Photo photo, [FromForm] IFormFile? newImage)
        {
            if (ModelState.IsValid)
            {
                if (newImage != null)
                {
                    _imageService.ValidateImage(newImage);

                    var oldImage = photo.ImageUrl;

                    if (!string.IsNullOrEmpty(oldImage))
                    {
                        _imageService.DeleteImage(oldImage);
                    }

                    var savedImage = await _imageService.SaveImageAsync(newImage);

                    photo.ImageUrl = savedImage;
                }

                _context.Photos.Update(photo);
                await _context.SaveChangesAsync();
                TempData["success"] = "Photo updated successfully.";

                return RedirectToAction("Photos");
            }
            else
            {
                TempData["error"] = "An error occured while updating the photo.";
            }

            return View("Photos");
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePhoto(int id)
        {
            if (id == 0 || id == null)
            {
                TempData["Error"] = "Invalid Photo ID.";
                return Json(new { success = false });
            }

            var photoFromDb = _context.Photos.FirstOrDefault(p => p.Id == id);

            if (photoFromDb != null)
            {
                _imageService.DeleteImage(photoFromDb.ImageUrl);
                _context.Photos.Remove(photoFromDb);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Photo deleted successfully!";

                return Json(new { success = true, id });
            }

            return RedirectToAction("Photos");
        }
    }
}
