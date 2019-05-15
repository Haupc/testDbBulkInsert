using System;
using System.Collections.Generic;

namespace testCS.Models
{
    public partial class Inventory
    {
        public Guid Id { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? WarehouseId { get; set; }
        public Guid? CategoryId { get; set; }
        public int? Quantity { get; set; }

        public virtual Category Category { get; set; }
        public virtual Product Product { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}
