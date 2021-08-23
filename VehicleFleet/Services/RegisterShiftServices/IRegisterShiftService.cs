using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleFleet.Models;

namespace VehicleFleet.Services.RegisterShiftServices
{
	public interface IRegisterShiftService
	{
		Task<RegisterShift> GetRegisterShiftAsync(int id);
		Task<IEnumerable<RegisterShift>> GetRegisterShiftsAsync();
		Task<RegisterShift> AddRegisterShiftAsync(RegisterShift registerShift);
		Task DeleteRegisterShiftAsync(int id);
	}
}
