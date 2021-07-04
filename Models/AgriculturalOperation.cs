using System;
using System.Collections.Generic;

#nullable disable

namespace AgriSoft.Models
{
    public partial class AgriculturalOperation
    {
        public AgriculturalOperation()
        {
            CropXoperations = new HashSet<CropXoperation>();
        }

        public int OperationId { get; set; }
        public string Title { get; set; }
        public string Period { get; set; }
        public string Description { get; set; }



        public int? StorageId { get; set; }
        public int? SupplierId { get; set; }

        public virtual Storage Storage { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<CropXoperation> CropXoperations { get; set; }
    }
}
