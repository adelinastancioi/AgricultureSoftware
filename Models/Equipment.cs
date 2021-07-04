using System;
using System.Collections.Generic;

#nullable disable

namespace AgriSoft.Models
{
    public partial class Equipment
    {
        public Equipment()
        {
            UseOfEquipments = new HashSet<UseOfEquipment>();
        }

        public int EquipmentId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int? StorageId { get; set; }
        public int? SupplierId { get; set; }

        public virtual Storage Storage { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<UseOfEquipment> UseOfEquipments { get; set; }
    }
}
