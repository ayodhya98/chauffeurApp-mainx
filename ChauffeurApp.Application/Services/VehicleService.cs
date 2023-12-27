using AutoMapper;
using ChauffeurApp.Application.DTOs;
using ChauffeurApp.Application.Services.IServices;
using ChauffeurApp.Core.Entities;
using ChauffeurApp.DataAccess.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ChauffeurApp.Application.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VehicleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<VehicleDTO>> CreateVehicle(VehicleCreateDTO vehicleCreateDTO)
        {
            if (vehicleCreateDTO == null) return Result<VehicleDTO>.Failure("Invalid input");
            Vehicle vehicle = _mapper.Map<Vehicle>(vehicleCreateDTO);
            await _unitOfWork.Vehicles.AddAsync(vehicle);
            await _unitOfWork.SaveAsync();

            VehicleDTO vehicleDTO = _mapper.Map<VehicleDTO>(vehicle);
            return Result<VehicleDTO>.Success(vehicleDTO);
        }

        public Task<Result<bool>> DeleteVehicle(long id)
        {
            throw new NotImplementedException();
        }


        public async Task<Result<List<VehicleDTO>>> FilterVehicles(long? typeId, int? seatingCapacity, long? brandId)
        {
            var vehicles = await _unitOfWork.Vehicles.FindAsync(v => v.AvailabilityStatus);
            var query = vehicles.AsQueryable();

            // Filter by vehicle type
            if (typeId.HasValue)
            {
                query = query.Where(v => v.TypeID == typeId);
            }

            // Filter by brand ID
            if (brandId.HasValue)
            {
                query = query.Where(v => v.BrandID == brandId);
            }

            // Filter by seating capacity
            if (seatingCapacity.HasValue)
            {
                query = query.Where(v => v.SeatingCapacity >= seatingCapacity.Value);
            }

            var listOfVehicles = await query.ToListAsync();
            List<VehicleDTO> vehicleDTOs = _mapper.Map<List<VehicleDTO>>(listOfVehicles);
            return Result<List<VehicleDTO>>.Success(vehicleDTOs);
        }

        public Task<Result<bool>> SoftDeleteVehicle(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<VehicleDTO>> UpdateVehicle(VehicleCreateDTO updatedDTO, long ID)
        {
            throw new NotImplementedException();
        }

        public Task<Result<List<VehicleDTO>>> ViewAllVehicle()
        {
            throw new NotImplementedException();
        }

        public Task<Result<VehicleDTO>> ViewVehicleByID(long id)
        {
            throw new NotImplementedException();
        }
    }
}
