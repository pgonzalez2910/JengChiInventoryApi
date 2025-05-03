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
        public IActionResult GetProductImage([FromQuery] string filename)
        {
            var imagePath = Path.Combine(@"C:\JengChi\Product Image", filename);

            if (!System.IO.File.Exists(imagePath))
                return NotFound();

            var imageBytes = System.IO.File.ReadAllBytes(imagePath);
            return File(imageBytes, "image/jpeg");
        }
        // or "image/png" based on your files

    }
}
