using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleFleet.Models;
using VehicleFleet.Repository.DriverRepositories;

namespace VehicleFleet.Services.DriverServices
{
	public class DriverService : IDriverService
	{
		private readonly IDriverRepository _driverRepository;

		public DriverService(IDriverRepository driverRepository)
		{
			_driverRepository = driverRepository;
		}

		public async Task<IEnumerable<Driver>> GetDriversAsync()
		{
			return await _driverRepository.GetDriversAsync();
		}

		public async Task<Driver> AddDriverAsync(Driver driver)
		{
			return await _driverRepository.AddDriversAsync(driver);
		}

		public async Task DeleteDriverAsync(int id)
		{
			await _driverRepository.DeleteDriverASync(id);
		}
	}
}