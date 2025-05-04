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
        public IActionResult GetProductByBarcode(string barcode)
        {
            try
            {
                var product = _context.Products.FirstOrDefault(p => p.Barcode == barcode);

                if (product == null)
                    return NotFound(new { message = $"No product found with barcode: {barcode}" });

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
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
        [HttpPost("update-onhand")]
        public IActionResult UpdateOnHand([FromBody] Product updatedProduct)
        {
            var normalizedItemNumber = updatedProduct.ItemNumber?.Trim();

            var product = _context.Products
                .FirstOrDefault(p => p.ItemNumber.Trim() == normalizedItemNumber);

            if (product == null)
                return NotFound("Product not found.");

            product.OnHand = updatedProduct.OnHand;
            _context.SaveChanges();

            return Ok("OnHand updated.");
        }

        
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }


    }

}