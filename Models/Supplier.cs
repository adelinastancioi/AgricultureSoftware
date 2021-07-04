using System;
using System.Collections.Generic;

#nullable disable

namespace AgriSoft.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            AgriculturalOperations = new HashSet<AgriculturalOperation>();
            Equipment = new HashSet<Equipment>();
            RawMaterials = new HashSet<RawMaterial>();
        }

        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string SupplierType { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public string Provides { get; set; }
        public decimal? Qtty { get; set; }
        public string Date { get; set; }

        public virtual ICollection<AgriculturalOperation> AgriculturalOperations { get; set; }
        public virtual ICollection<Equipment> Equipment { get; set; }
        public virtual ICollection<RawMaterial> RawMaterials { get; set; }
    }
}
