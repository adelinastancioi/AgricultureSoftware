using System.Collections.Generic;

#nullable disable

namespace AgriSoft.Models
{
    public partial class Crop
    {
        public Crop()
        {
            CropXoperations = new HashSet<CropXoperation>();
            UseOfEquipments = new HashSet<UseOfEquipment>();
            UseOfRawMaterials = new HashSet<UseOfRawMaterial>();
        }

        public int CropId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string PlantingPeriod { get; set; }
        public string Description { get; set; }
        public int? StorageId { get; set; }
        public string SupplierName { get; set; }
        public string Teren { get; set; }
        public string TipTeren { get; set; }
        public string DescriereTeren { get; set; }
        public string MateriePrimaFertilizare { get; set; }
        public string Cantitate { get; set; }
        public string PerioadaFertilizare { get; set; }
        public string UtilajFertilizare { get; set; }
        public string DescriereFertilizare { get; set; }
        public string PerioadaSemanat { get; set; }
        public string UtilajSemanat { get; set; }
        public string DistantaSemanat { get; set; }
        public string DescriereSemanat { get; set; }
        public string DenumireSubstanta { get; set; }
        public string CantitateSubstanta { get; set; }
        public string PerioadaCombatere { get; set; }
        public string UtilajCombatere { get; set; }
        public string DescriereCombatere { get; set; }
        public string PerioadaRecoltare { get; set; }
        public string UtilajRecoltare { get; set; }
        public string DescriereRecoltare { get; set; }
        public string LocatieDepozitare { get; set; }
        public string DescriereDepozitare { get; set; }

        public virtual Storage Storage { get; set; }
        public virtual ICollection<CropXoperation> CropXoperations { get; set; }
        public virtual ICollection<UseOfEquipment> UseOfEquipments { get; set; }
        public virtual ICollection<UseOfRawMaterial> UseOfRawMaterials { get; set; }
    }
}
