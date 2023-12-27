using ChauffeurApp.Application.DTOs;

namespace ChauffeurApp.Application.Services.IServices
{
    public interface IVehicleService
    {
        Task<Result<VehicleDTO>> CreateVehicle(VehicleCreateDTO vehicleCreateDTO);
        Task<Result<List<VehicleDTO>>> ViewAllVehicle();
        Task<Result<VehicleDTO>> ViewVehicleByID(long id);
        Task<Result<bool>> DeleteVehicle(long id);
        Task<Result<VehicleDTO>> UpdateVehicle(VehicleCreateDTO updatedDTO, long ID);
        Task<Result<bool>> SoftDeleteVehicle(long id);
        Task<Result<List<VehicleDTO>>> FilterVehicles(long? typeId, int? seatingCapacity, long? brandId);
    }
}
