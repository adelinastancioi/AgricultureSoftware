using System;
using System.Collections.Generic;

#nullable disable

namespace AgriSoft.Models
{
    public partial class Storage
    {
        public Storage()
        {
            AgriculturalOperations = new HashSet<AgriculturalOperation>();
            Crops = new HashSet<Crop>();
            Equipment = new HashSet<Equipment>();
            RawMaterials = new HashSet<RawMaterial>();
        }

        public int StorageId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        public virtual ICollection<AgriculturalOperation> AgriculturalOperations { get; set; }
        public virtual ICollection<Crop> Crops { get; set; }
        public virtual ICollection<Equipment> Equipment { get; set; }
        public virtual ICollection<RawMaterial> RawMaterials { get; set; }
    }
}
