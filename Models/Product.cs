using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JengChiInventoryApi.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public string ItemNumber { get; set; } = "";

        [Column("Product")]
        public string? ProductName { get; set; }

        public string? Vendor { get; set; }

        public int? LastOrderedQty { get; set; }

        public DateTime? LastOrderedDate { get; set; }

        public decimal? Price { get; set; }

        [Column("Image")]
        public string? ImageFilename { get; set; }

        public string? Barcode { get; set; }

        public int? OnHand { get; set; }

        public string? Department { get; set; }
    }
}