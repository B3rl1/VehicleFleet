using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleFleet.Models;

namespace VehicleFleet.Repository.VehicleRepositories
{
	public interface IVehicleRepository
	{
		Task<Vehicle> GetVehicleAsync(int id);
		Task<IEnumerable<Vehicle>> GetVehiclesAsync();
		Task<Vehicle> AddVehicleAsync(Vehicle vehicle);
		Task DeleteVehicleAsync(int id);
		Task<Vehicle> UpdateVehicleAsync(Vehicle vehicle);
	}
}
