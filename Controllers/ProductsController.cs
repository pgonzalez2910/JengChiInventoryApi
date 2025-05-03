using Microsoft.AspNetCore.Mvc;
using JengChiInventoryApi.Data;
using JengChiInventoryApi.Models;
using System.Linq;

namespace JengChiInventoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly InventoryContext _context;

        public ProductsController(InventoryContext context)
        {
            _context = context;
        }

        [HttpGet("barcode/{barcode}")]
        public ActionResult<Product> GetProductByBarcode(string barcode)
        {
            var product = _context.Products.FirstOrDefault(p => p.Barcode == barcode);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }



        [HttpGet("image")]
        public IActionResult GetImage(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
                return BadRequest("Filename is required.");

            var imageFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images");

            // Look for any file that starts with the name (any extension)
            var file = Directory.GetFiles(imageFolder)
                                .FirstOrDefault(f => Path.GetFileNameWithoutExtension(f).Equals(filename, StringComparison.OrdinalIgnoreCase));

            if (file == null)
                return NotFound("Image not found.");

            var contentType = file.EndsWith(".png") ? "image/png" : "image/jpeg";
            var image = System.IO.File.ReadAllBytes(file);
            return File(image, contentType);
        }
    }
    }