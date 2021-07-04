using System;
using System.Collections.Generic;

#nullable disable

namespace AgriSoft.Models
{
    public partial class CropXoperation
    {
        public int OperationId { get; set; }
        public int CropId { get; set; }
        public string Description { get; set; }

        public virtual Crop Crop { get; set; }
        public virtual AgriculturalOperation Operation { get; set; }
    }
}
