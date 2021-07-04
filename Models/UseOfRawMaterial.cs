using System;
using System.Collections.Generic;

#nullable disable

namespace AgriSoft.Models
{
    public partial class UseOfRawMaterial
    {
        public int RawMaterialId { get; set; }
        public int CropId { get; set; }
        public string Usage { get; set; }

        public virtual Crop Crop { get; set; }
        public virtual RawMaterial RawMaterial { get; set; }
    }
}
