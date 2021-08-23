using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using VehicleFleet.Models;

namespace VehicleFleet.Repository.DriverRepositories
{
	public class DriverRepository : IDriverRepository
	{
		public async Task<Driver> GetDriverAsync(int id)
		{
			Driver result = null;

			using (var vehicleContext = new VehicleFleetContext())
			{
				result = await vehicleContext.Drivers.FirstOrDefaultAsync(d => d.Id == id);
			}

			return result;
		}

		public async Task<IEnumerable<Driver>> GetDriversAsync()
		{
			var result = new List<Driver>();

			using (var vehicleContext = new VehicleFleetContext())
			{
				result = await vehicleContext.Drivers.ToListAsync();
			}

			return result;
		}

		public async Task<Driver> AddDriversAsync(Driver driver)
		{
			Driver result = null;

			using (var vehicleContext = new VehicleFleetContext())
			{
				result = vehicleContext.Drivers.Add(driver);
				await vehicleContext.SaveChangesAsync();
			}

			return result;
		}

		public async Task DeleteDriverASync(int id)
		{
			using (var vehicleContext = new VehicleFleetContext())
			{
				var vehicle = await vehicleContext.Drivers.FirstOrDefaultAsync(v => v.Id == id);

				vehicleContext.Entry(vehicle).State = EntityState.Deleted;

				await vehicleContext.SaveChangesAsync();
			}
		}
	}
}