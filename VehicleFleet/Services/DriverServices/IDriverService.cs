using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleFleet.Models;

namespace VehicleFleet.Services.DriverServices
{
	public interface IDriverService
	{
		Task<IEnumerable<Driver>> GetDriversAsync();
		Task<Driver> AddDriverAsync(Driver driver);
		Task DeleteDriverAsync(int id);
	}
}