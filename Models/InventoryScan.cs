
using System;

namespace JengChiInventoryApi.Models
{
    public class InventoryScan
    {
        public int Id { get; set; }
        public string ItemNumber { get; set; } = "";
        public int Quantity { get; set; }
        public DateTime ScannedAt { get; set; } = DateTime.Now;
        public string ScannedBy { get; set; } = "";
    }
}