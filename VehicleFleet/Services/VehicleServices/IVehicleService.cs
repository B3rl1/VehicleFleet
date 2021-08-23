using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleFleet.Models;
using VehicleFleet.ViewModels.VehicleViewModels;

namespace VehicleFleet
{
	public interface IVehicleService
	{
		Task<Vehicle> GetVehicleAsync(int id);
		Task<IEnumerable<Vehicle>> GetVehiclesAsync();
		Task<Vehicle> AddVehicleAsync(Vehicle vehicle);
		Task<Vehicle> UpdateVehicleAsync(Vehicle vehicle);
		Task DeleteVehicleAsync(int id);
		decimal GetResidualValueByYear(VehicleViewModel vehicleViewModel, int year);
		decimal GetResidualValue(VehicleViewModel vehicleViewModel, decimal fuelConsumption);
	}
}
