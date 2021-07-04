using AgriSoft.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgriSoft.Services
{
    public interface ICropRepository 
    {
        Task<List<RawMaterial>> GetRawMaterials();
        Task<List<Equipment>> GetEquipments();
        Task<List<Crop>> GetCrops();
        Task<List<Storage>> GetStorages();
        Task<List<Client>> GetClients();
        Task<List<Supplier>> GetSuppliers();
        System.Threading.Tasks.Task RemoveRawMaterial(int rawMaterialId);
        System.Threading.Tasks.Task RemoveTool(int toolId);
        System.Threading.Tasks.Task RemoveCrop(int cropId);
        System.Threading.Tasks.Task RemoveStorage(int storageId);
        System.Threading.Tasks.Task RemoveSupplier(int supplierId);
        System.Threading.Tasks.Task RemoveClient(int clientId);
        System.Threading.Tasks.Task AddEditRawMaterial(RawMaterial rawMaterial);
        System.Threading.Tasks.Task AddEditTool(Equipment equipment);
        System.Threading.Tasks.Task AddEditCrop(Crop crop);
        System.Threading.Tasks.Task AddEditStorage(Storage storage);
        System.Threading.Tasks.Task AddEditClient(Client client);
        System.Threading.Tasks.Task AddEditSupplier(Supplier supplier);
    }
}
