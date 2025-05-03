using Microsoft.AspNetCore.Mvc;
using JengChiInventoryApi.Data;
using JengChiInventoryApi.Models;

namespace JengChiInventoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryScansController : ControllerBase
    {
        private readonly InventoryContext _context;

        public InventoryScansController(InventoryContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostInventoryScan([FromBody] InventoryScan scan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.InventoryScans.Add(scan);
            await _context.SaveChangesAsync();

            return Ok(scan);
        }
    }
}