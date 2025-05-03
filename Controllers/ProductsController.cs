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

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", filename + ".jpg");

            if (!System.IO.File.Exists(filePath))
                return NotFound("Image not found.");

            var image = System.IO.File.ReadAllBytes(filePath);
            return File(image, "image/jpeg");
        }

    }
    }