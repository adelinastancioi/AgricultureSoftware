using System;
using System.Collections.Generic;

#nullable disable

namespace AgriSoft.Models
{
    public partial class UseOfEquipment
    {
        public int EquipmentId { get; set; }
        public int CropId { get; set; }
        public string Usage { get; set; }

        public virtual Crop Crop { get; set; }
        public virtual Equipment Equipment { get; set; }
    }
}
