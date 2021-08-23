using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using VehicleFleet.Models;

namespace VehicleFleet.Repository.RegisterShiftRepositories
{
	public class RegisterShiftRepository : IRegisterShiftRepository
	{
		public async Task<RegisterShift> GetRegisterShiftAsync(int id)
		{
			RegisterShift result = null;

			using (var vehicleContext = new VehicleFleetContext())
			{
				result = await vehicleContext.RegisterShifts.Include(v => v.Driver).Include(v => v.Vehicle).FirstOrDefaultAsync(v => v.Id == id);
			}

			return result;
		}

		public async Task<IEnumerable<RegisterShift>> GetRegisterShiftsAsync()
		{
			var result = new List<RegisterShift>();

			using (var vehicleContext = new VehicleFleetContext())
			{
				result = await vehicleContext.RegisterShifts.Include(v => v.Driver).ToListAsync();
			}

			return result;
		}

		public async Task<RegisterShift> AddRegisterShiftAsync(RegisterShift registerShift)
		{
			RegisterShift result = null;

			using (var vehicleContext = new VehicleFleetContext())
			{
				result = vehicleContext.RegisterShifts.Add(registerShift);
				await vehicleContext.SaveChangesAsync();
			}

			return result;
		}

		public async Task DeleteRegisterShiftAsync(int id)
		{
			using (var vehicleContext = new VehicleFleetContext())
			{
				var registerShift = await vehicleContext.RegisterShifts.FirstOrDefaultAsync(v => v.Id == id);

				vehicleContext.Entry(registerShift).State = EntityState.Deleted;

				await vehicleContext.SaveChangesAsync();
			}
		}
	}
}