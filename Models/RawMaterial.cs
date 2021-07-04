using System;
using System.Collections.Generic;

#nullable disable

namespace AgriSoft.Models
{
    public partial class RawMaterial
    {
        public RawMaterial()
        {
            UseOfRawMaterials = new HashSet<UseOfRawMaterial>();
        }

        public int RawMaterialId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string ExpirationDate { get; set; }
        public string Description { get; set; }
        public int? StorageId { get; set; }
        public int? SupplierId { get; set; }

        public virtual Storage Storage { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<UseOfRawMaterial> UseOfRawMaterials { get; set; }
    }
}
