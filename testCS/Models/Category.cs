using System;
using System.Collections.Generic;

namespace testCS.Models
{
    public partial class Category
    {
        public Category()
        {
            Inventories = new HashSet<Inventory>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ParentId { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
