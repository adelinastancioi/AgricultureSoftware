using AgriSoft.Models;
using AgriSoft.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AgriSoft.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CropController : Controller
    {
        private readonly ICropRepository _cropRepository;

        public CropController(ICropRepository cropRepository)
        {
            _cropRepository = cropRepository;
        }

        [HttpGet("raw-materials")]
        public async Task<IActionResult> GetRawMaterials()
        {
            var result = await _cropRepository.GetRawMaterials();
            return Ok(result);
        }

        [HttpGet("equipments")]
        public async Task<IActionResult> GetEquipments()
        {
            var result = await _cropRepository.GetEquipments();
            return Ok(result);
        }

        [HttpGet("crops")]
        public async Task<IActionResult> GetCrops()
        {
            var result = await _cropRepository.GetCrops();
            return Ok(result);
        }

        [HttpGet("storages")]
        public async Task<IActionResult> GetStorages()
        {
            var result = await _cropRepository.GetStorages();
            return Ok(result);
        }

        [HttpGet("clients")]
        public async Task<IActionResult> GetClients()
        {
            var result = await _cropRepository.GetClients();
            return Ok(result);
        }

        [HttpGet("suppliers")]
        public async Task<IActionResult> GetSuppliers()
        {
            var result = await _cropRepository.GetSuppliers();
            return Ok(result);
        }

        [HttpDelete("remove-material")]
        public async Task<IActionResult> RemoveRawMaterial([FromQuery] int rawMaterialId)
        {
            await _cropRepository.RemoveRawMaterial(rawMaterialId);
            return Ok();
        }

        [HttpDelete("remove-crop")]
        public async Task<IActionResult> RemoveCrop([FromQuery] int cropId)
        {
            await _cropRepository.RemoveCrop(cropId);
            return Ok();
        }

        [HttpDelete("remove-tool")]
        public async Task<IActionResult> RemoveEquipment([FromQuery] int equipmentId)
        {
            await _cropRepository.RemoveTool(equipmentId);
            return Ok();
        }

        [HttpDelete("remove-storage")]
        public async Task<IActionResult> RemoveStorage([FromQuery] int storageId)
        {
            await _cropRepository.RemoveStorage(storageId);
            return Ok();
        }

        [HttpDelete("remove-client")]
        public async Task<IActionResult> RemoveClient([FromQuery] int clientId)
        {
            await _cropRepository.RemoveClient(clientId);
            return Ok();
        }

        [HttpDelete("remove-supplier")]
        public async Task<IActionResult> RemoveSupplier([FromQuery] int supplierId)
        {
            await _cropRepository.RemoveSupplier(supplierId);
            return Ok();
        }

        [HttpPut("save-material")]
        public async Task<IActionResult> SaveMaterial([FromBody] RawMaterial rawMaterial)
        {
            await _cropRepository.AddEditRawMaterial(rawMaterial);
            return Ok();
        }

        [HttpPut("save-tool")]
        public async Task<IActionResult> SaveTool([FromBody] Equipment equipment)
        {
            await _cropRepository.AddEditTool(equipment);
            return Ok();
        }

        [HttpPut("save-crop")]
        public async Task<IActionResult> SaveCrop([FromBody] Crop crop)
        {
            await _cropRepository.AddEditCrop(crop);
            return Ok();
        }

        [HttpPut("save-storage")]
        public async Task<IActionResult> SaveStorage([FromBody] Storage storage)
        {
            await _cropRepository.AddEditStorage(storage);
            return Ok();
        }

        [HttpPut("save-client")]
        public async Task<IActionResult> SaveClient([FromBody] Client client)
        {
            await _cropRepository.AddEditClient(client);
            return Ok();
        }

        [HttpPut("save-supplier")]
        public async Task<IActionResult> SaveSupplier([FromBody] Supplier supplier)
        {
            await _cropRepository.AddEditSupplier(supplier);
            return Ok();
        }
    }
}
