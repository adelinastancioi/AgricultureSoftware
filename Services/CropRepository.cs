using AgriSoft.Context;
using AgriSoft.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgriSoft.Services
{
    public class CropRepository : ICropRepository
    {
        private FarmContext _context;

        public CropRepository(FarmContext context)
        {
            _context = context;
        }

        public async Task<List<Equipment>> GetEquipments()
        {
            var equipments = await _context.Equipment
              .Include(x => x.Supplier)
              .Include(x => x.Storage)
              .OrderBy(x => x.EquipmentId)
              .ToListAsync();

            return equipments;
        }

        public async Task<List<RawMaterial>> GetRawMaterials()
        {
            var materials = await _context.RawMaterials
                 .Include(x => x.Supplier)
                 .Include(x => x.Storage)
                 .OrderBy(x => x.RawMaterialId)
                 .ToListAsync();
            return materials;
        }

        public async Task<List<Crop>> GetCrops()
        {
            var crops = await _context.Crops
                .Include(x => x.CropXoperations)
                .Include(x => x.Storage)
                .Include(x => x.UseOfEquipments)
                .Include(x => x.UseOfRawMaterials)
                .OrderBy(x => x.CropId)
                .ToListAsync();
            return crops;
        }

        public RawMaterial GetRawMaterial(int id)
        {
            var material = _context.RawMaterials
                .Include(x => x.Supplier)
                 .Include(x => x.Storage)
                .Where(x => x.RawMaterialId == id)
                .FirstOrDefault();
            return material;
        }

        public Equipment GetTool(int id)
        {
            var equipment = _context.Equipment
                .Include(x => x.Supplier)
                 .Include(x => x.Storage)
                .Where(x => x.EquipmentId == id)
                .FirstOrDefault();
            return equipment;
        }

        public async Task<List<Storage>> GetStorages()
        {
            var storages = await _context.Storages
                 .Include(x => x.AgriculturalOperations)
                 .Include(x => x.Crops)
                 .Include(x => x.Equipment)
                 .Include(x => x.RawMaterials)
                 .ToListAsync();
            return storages;
        }


        public async Task<List<Client>> GetClients()
        {
            var clients = await _context.Clients
                 .ToListAsync();

            return clients;
        }

        public async Task<List<Supplier>> GetSuppliers()
        {
            var suppliers = await _context.Suppliers
                 .ToListAsync();

            return suppliers;
        }


        public async System.Threading.Tasks.Task RemoveRawMaterial(int rawMaterialId)
        {
            var material = GetRawMaterial(rawMaterialId);
            if (material != null)
            {
                _context.RawMaterials.Remove(material);
                await _context.SaveChangesAsync();
            }
        }

        public async System.Threading.Tasks.Task RemoveTool(int toolId)
        {
            var equipment = GetTool(toolId);
            if (equipment != null)
            {
                _context.Equipment.Remove(equipment);
                await _context.SaveChangesAsync();
            }
        }

        public async System.Threading.Tasks.Task AddEditRawMaterial(RawMaterial rawMaterial)
        {
            if (rawMaterial.RawMaterialId == 0)
                _context.RawMaterials.Add(rawMaterial);
            else
                _context.RawMaterials.Update(rawMaterial);

            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task AddEditTool(Equipment equipment)
        {
            if (equipment.EquipmentId == 0)
                _context.Equipment.Add(equipment);
            else
                _context.Equipment.Update(equipment);

            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task RemoveCrop(int cropId)
        {
            var crop = _context.Crops
                 .Include(x => x.Storage)
                 .Include(x => x.UseOfRawMaterials)
                 .Include(x => x.CropXoperations)
                 .Include(x => x.UseOfRawMaterials)
               .Where(x => x.CropId == cropId)
               .FirstOrDefault();

            if (crop != null)
            {
                _context.Crops.Remove(crop);
                await _context.SaveChangesAsync();
            }
        }

        public async System.Threading.Tasks.Task RemoveStorage(int storageId)
        {
            var storage = _context.Storages
               .Where(x => x.StorageId == storageId)
               .FirstOrDefault();

            if (storage != null)
            {
                _context.Storages.Remove(storage);
                await _context.SaveChangesAsync();
            }
        }

        public async System.Threading.Tasks.Task RemoveSupplier(int supplierId)
        {
            var supplier = _context.Suppliers
              .Where(x => x.SupplierId == supplierId)
              .FirstOrDefault();

            if (supplier != null)
            {
                _context.Suppliers.Remove(supplier);
                await _context.SaveChangesAsync();
            }
        }

        public async System.Threading.Tasks.Task RemoveClient(int clientId)
        {
            var client = _context.Clients
               .Where(x => x.ClientId == clientId)
               .FirstOrDefault();

            if (client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }
        }

        public async System.Threading.Tasks.Task AddEditCrop(Crop crop)
        {
            if (crop.CropId == 0)
                _context.Crops.Add(crop);
            else
                _context.Crops.Update(crop);

            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task AddEditStorage(Storage storage)
        {
            if (storage.StorageId == 0)
                _context.Storages.Add(storage);
            else
                _context.Storages.Update(storage);

            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task AddEditClient(Client client)
        {
            if (client.ClientId == 0)
                _context.Clients.Add(client);
            else
                _context.Clients.Update(client);

            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task AddEditSupplier(Supplier supplier)
        {
            if (supplier.SupplierId == 0)
                _context.Suppliers.Add(supplier);
            else
                _context.Suppliers.Update(supplier);

            await _context.SaveChangesAsync();
        }
    }
}
