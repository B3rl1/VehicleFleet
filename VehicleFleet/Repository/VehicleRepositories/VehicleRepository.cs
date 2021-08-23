using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using VehicleFleet.Models;

namespace VehicleFleet.Repository.VehicleRepositories
{
	public class VehicleRepository : IVehicleRepository
	{
		public async Task<Vehicle> GetVehicleAsync(int id)
		{
			Vehicle result = null;

			using (var vehicleContext = new VehicleFleetContext())
			{
				result = await vehicleContext.Vehicles.FirstOrDefaultAsync(v => v.Id == id);
			}

			return result;
		}

		public async Task<IEnumerable<Vehicle>> GetVehiclesAsync()
		{
			var result = new List<Vehicle>();

			using (var vehicleContext = new VehicleFleetContext())
			{
				result = await vehicleContext.Vehicles.ToListAsync();
			}

			return result;
		}

		public async Task<Vehicle> AddVehicleAsync(Vehicle vehicle)
		{
			Vehicle result = null;

			using (var vehicleContext = new VehicleFleetContext())
			{
				result = vehicleContext.Vehicles.Add(vehicle);
				await vehicleContext.SaveChangesAsync();
			}

			return result;
		}

		public async Task DeleteVehicleAsync(int id)
		{
			using (var vehicleContext = new VehicleFleetContext())
			{
				var vehicle = await vehicleContext.Vehicles.FirstOrDefaultAsync(v => v.Id == id);

				vehicleContext.Entry(vehicle).State = EntityState.Deleted;

				await vehicleContext.SaveChangesAsync();
			}
		}

		public async Task<Vehicle> UpdateVehicleAsync(Vehicle vehicle)
		{
			using (var vehicleContext = new VehicleFleetContext())
			{
				vehicleContext.Entry(vehicle).State = EntityState.Modified;

				await vehicleContext.SaveChangesAsync();
			}

			return vehicle;
		}
	}
}