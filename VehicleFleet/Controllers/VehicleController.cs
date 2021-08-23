using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VehicleFleet.Models;
using VehicleFleet.Services.RegisterShiftServices;
using VehicleFleet.ViewModels;
using VehicleFleet.ViewModels.DriverViewModels;
using VehicleFleet.ViewModels.RegisterShiftViewModels;
using VehicleFleet.ViewModels.VehicleViewModels;

namespace VehicleFleet.Controllers
{
    public class VehicleController : Controller
    {
	    private readonly IVehicleService _vehicleService;
	    private readonly IRegisterShiftService _registerShiftService;

	    public VehicleController(IVehicleService vehicleService, IRegisterShiftService registerShiftService)
	    {
		    _vehicleService = vehicleService;
		    _registerShiftService = registerShiftService;
	    }
        
        public async Task<ActionResult> Index()
        {
	        var vehicles = await _vehicleService.GetVehiclesAsync();

	        var vehiclesViewModel = vehicles.Select(v => new VehicleViewModel
	        {
		        Id = v.Id,
		        Name = v.Name,
		        EngineHP = v.EngineHP,
				NewCarCost = v.NewCarCost,
				ServiceRatio = v.ServiceRatio
	        });

            return View(vehiclesViewModel);
        }

        public ActionResult AddVehicle()
        {
	        var vehicleViewModel = new VehicleEditViewModel
	        {
		        Title = "Добавление нового автомобиля",
		        AddButtonTitle = "Добавить",
		        RedirectUrl = Url.Action("Index", "Vehicle")
	        };

	        return View(vehicleViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> AddNewVehicle(VehicleEditViewModel vehicleViewModel, string redirectUrl)
        {
	        if (!ModelState.IsValid)
	        {
		        return RedirectToAction("AddVehicle");
	        }

	        var vehicle = new Vehicle
	        {
		        Name = vehicleViewModel.Name,
		        EngineHP = vehicleViewModel.EngineHP,
				NewCarCost = vehicleViewModel.NewCarCost
	        };

	        await _vehicleService.AddVehicleAsync(vehicle);

	        return RedirectToLocal(redirectUrl);
        }

        [HttpPost]
        public async Task<ActionResult> SaveVehicle(VehicleEditViewModel vehicleViewModel, string redirectUrl)
        {
	        if (!ModelState.IsValid)
	        {
		        return RedirectToAction("EditVehicle");
	        }

	        var vehicle = await _vehicleService.GetVehicleAsync(vehicleViewModel.Id);
	        if (vehicle!= null)
	        {
		        vehicle.Name = vehicleViewModel.Name;
		        vehicle.EngineHP = vehicleViewModel.EngineHP;
		        vehicle.NewCarCost = vehicleViewModel.NewCarCost;

				await _vehicleService.UpdateVehicleAsync(vehicle);
	        }

	        return RedirectToLocal(redirectUrl);
        }

        public async Task<ActionResult> EditVehicle(int id)
        {
	        var vehicle = await _vehicleService.GetVehicleAsync(id);

	        ViewBag.VehicleId = vehicle.Id;

	        var registerShifts = await _registerShiftService.GetRegisterShiftsAsync();

	        var registerShiftsView = registerShifts.Where(r => r.VehicleId == id).Select(r => new RegisterShiftViewModel
	        {
		        Id = r.Id,
		        TimeOfBeginning = r.TimeOfBeginning,
		        TimeOfEnd = r.TimeOfEnd,
		        DriverId = r.DriverId,
		        Driver = new DriverViewModel
		        {
			        FirstName = r.Driver.FirstName,
			        LastName = r.Driver.LastName,
			        FullName = r.Driver.FullName
		        },
		        VehicleId = r.VehicleId,
		        Mileage = r.Mileage.ToString(),
		        FuelConsumption = r.FuelConsumption.ToString()
	        }).OrderBy(r => r.TimeOfBeginning);


			var vehicleViewModel = new VehicleEditViewModel
			{
				Title = "Изменение автомобиля",
				AddButtonTitle = "Сохранить",
				RedirectUrl = Url.Action("Index", "Vehicle"),
				Id = vehicle.Id,
				Name = vehicle.Name,
				EngineHP = vehicle.EngineHP,
				NewCarCost = vehicle.NewCarCost,
				ServiceRatio = vehicle.ServiceRatio,
				ResidualValue = vehicle.NewCarCost,
				FuelConsumptionSum = registerShifts.Where(r => r.VehicleId == id).Sum(r => r.FuelConsumption).ToString(),
				MileageSum = registerShifts.Where(r => r.VehicleId == id).Sum(r => r.Mileage).ToString(),
				RegisterShifts = registerShiftsView
	        };

	        var years = vehicleViewModel.RegisterShifts.Select(r => r.TimeOfBeginning.Year).Distinct().ToList();

	        foreach (var year in years)
	        {
		        decimal cost = _vehicleService.GetResidualValueByYear(vehicleViewModel, year);
				vehicleViewModel.ResidualValueByYear.Add(year.ToString(), String.Format("{0:f2}", cost));
	        }
			
	        return View(vehicleViewModel);
        }

        public async Task<ActionResult> DeleteVehicle(int id)
        {
	        await _vehicleService.DeleteVehicleAsync(id);

	        return RedirectToAction("Index");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
	        if (Url.IsLocalUrl(returnUrl))
	        {
		        return Redirect(returnUrl);
	        }

	        return RedirectToAction("Index", "Vehicle");
        }
    }
}