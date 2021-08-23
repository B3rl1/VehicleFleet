using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using VehicleFleet.Models;
using VehicleFleet.Repository.VehicleRepositories;
using VehicleFleet.ViewModels.VehicleViewModels;

namespace VehicleFleet
{
	public class VehicleService : IVehicleService
	{
		private const decimal FuelCost = 47.5m;
		private readonly IVehicleRepository _vehicleRepository;

		public VehicleService(IVehicleRepository vehicleRepository)
		{
			_vehicleRepository = vehicleRepository;
		}

		public async Task<Vehicle> AddVehicleAsync(Vehicle vehicle)
		{
			return await _vehicleRepository.AddVehicleAsync(vehicle);
		}

		public async Task<Vehicle> UpdateVehicleAsync(Vehicle vehicle)
		{
			return await _vehicleRepository.UpdateVehicleAsync(vehicle);
		}

		public async Task DeleteVehicleAsync(int id)
		{
			await _vehicleRepository.DeleteVehicleAsync(id);
		}

		public async Task<Vehicle> GetVehicleAsync(int id)
		{
			return await _vehicleRepository.GetVehicleAsync(id);
		}

		public async Task<IEnumerable<Vehicle>> GetVehiclesAsync()
		{
			return await _vehicleRepository.GetVehiclesAsync();
		}

		public decimal GetResidualValueByYear(VehicleViewModel vehicleViewModel, int year)
		{
			var tmpFuelConsumption = vehicleViewModel.RegisterShifts.Where(r=> r.VehicleId == vehicleViewModel.Id).Where(r => r.TimeOfBeginning.Year == year)
				.Select(r => r.FuelConsumption).ToList();

			List<string> fuelConsumptionStr = new List<string>();

			foreach (var str in tmpFuelConsumption)
			{
				fuelConsumptionStr.Add(str.Replace(',','.'));
			}

			var fuelConsumptionByYear = fuelConsumptionStr.Sum(r => decimal.Parse(r, CultureInfo.InvariantCulture));

			decimal cost = GetResidualValue(vehicleViewModel, fuelConsumptionByYear);

			return cost;
		}

		public decimal GetResidualValue(VehicleViewModel vehicleViewModel, decimal fuelConsumption)
		{
			decimal cost = 0.0m;
			cost += vehicleViewModel.NewCarCost * (vehicleViewModel.ServiceRatio * 1.0m / 100.0m);
			cost += fuelConsumption * FuelCost;
			cost += vehicleViewModel.EngineHP * GetVehicleTaxes(vehicleViewModel.EngineHP) * GetLuxuryTaxes(vehicleViewModel.NewCarCost);

			vehicleViewModel.ResidualValue -= cost;
			return vehicleViewModel.ResidualValue * 1.0m;
		}

		private int GetVehicleTaxes(int engineHp)
		{
			if (engineHp <= 125)
				return 25;
			else if (engineHp <= 150)
				return 35;
			else if (engineHp <= 175)
				return 45;
			else if (engineHp <= 200)
				return 50;
			else if (engineHp <= 225)
				return 65;
			else if (engineHp <= 250)
				return 75;
			else if (engineHp > 250)
				return 150;

			return 12;
		}

		private decimal GetLuxuryTaxes(int costValue)
		{
			if (costValue >= 3 * Math.Pow(10, 6) && costValue <= 5 * Math.Pow(10, 6))
				return 1.1m;
			else if (costValue > 5 * Math.Pow(10, 6) && costValue <= 10 * Math.Pow(10, 6))
				return 2;
			else if (costValue > 10 * Math.Pow(10, 6) && costValue <= 15 * Math.Pow(10, 6))
				return 3;
			else if (costValue > 15 * Math.Pow(10, 6))
				return 3;

			return 1;
		}
	}
}