using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleFleet.Models;
using VehicleFleet.Repository.RegisterShiftRepositories;

namespace VehicleFleet.Services.RegisterShiftServices
{
	public class RegisterShiftService : IRegisterShiftService
	{
		private readonly IRegisterShiftRepository _registerShiftRepository;

		public RegisterShiftService(IRegisterShiftRepository registerShiftRepository)
		{
			_registerShiftRepository = registerShiftRepository;
		}

		public async Task<RegisterShift> GetRegisterShiftAsync(int id)
		{
			return await _registerShiftRepository.GetRegisterShiftAsync(id);
		}

		public async Task<IEnumerable<RegisterShift>> GetRegisterShiftsAsync()
		{
			return await _registerShiftRepository.GetRegisterShiftsAsync();
		}

		public async Task<RegisterShift> AddRegisterShiftAsync(RegisterShift registerShift)
		{
			return await _registerShiftRepository.AddRegisterShiftAsync(registerShift);
		}

		public async Task DeleteRegisterShiftAsync(int id)
		{
			await _registerShiftRepository.DeleteRegisterShiftAsync(id);
		}
	}
}