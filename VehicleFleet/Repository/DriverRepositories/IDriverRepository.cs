using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleFleet.Models;

namespace VehicleFleet.Repository.DriverRepositories
{
	public interface IDriverRepository
	{
		Task<Driver> GetDriverAsync(int id);
		Task<IEnumerable<Driver>> GetDriversAsync();
		Task<Driver> AddDriversAsync(Driver driver);
		Task DeleteDriverASync(int id);
	}
}
