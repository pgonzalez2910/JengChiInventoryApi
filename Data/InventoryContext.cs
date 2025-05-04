    using Microsoft.EntityFrameworkCore;
    using JengChiInventoryApi.Models;

    namespace JengChiInventoryApi.Data
    {
        public class InventoryContext : DbContext
        {
            public InventoryContext(DbContextOptions<InventoryContext> options)
                : base(options)
            {
            }

            public DbSet<Product> Products { get; set; }
            public DbSet<InventoryScan> InventoryScans { get; set; }
            // Add more DbSets if needed
        }
    }
