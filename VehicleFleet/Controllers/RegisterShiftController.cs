using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VehicleFleet.Models;
using VehicleFleet.Services.DriverServices;
using VehicleFleet.Services.RegisterShiftServices;
using VehicleFleet.ViewModels;
using VehicleFleet.ViewModels.DriverViewModels;
using VehicleFleet.ViewModels.RegisterShiftViewModels;

namespace VehicleFleet.Controllers
{
    public class RegisterShiftController : Controller
    {
	    private readonly IRegisterShiftService _registerShiftService;
	    private readonly IDriverService _driverService;

	    public RegisterShiftController(IRegisterShiftService registerShiftService, IDriverService driverService)
	    {
		    _registerShiftService = registerShiftService;
		    _driverService = driverService;
	    }

	    public async Task<ActionResult> Partial()
	    {
		    return View(await GetRegisterShiftViewModel());
		}

	    public async Task<ActionResult> Index()
	    {
		    return View(await GetRegisterShiftViewModel());
        }

	    private async Task<IEnumerable<RegisterShiftViewModel>> GetRegisterShiftViewModel()
	    {
		    var registerShifts = await _registerShiftService.GetRegisterShiftsAsync();
		    var registerShiftsViewModel = registerShifts.Select(r => new RegisterShiftViewModel
		    {
			    Id = r.Id,
				TimeOfBeginning = r.TimeOfBeginning,
				TimeOfEnd = r.TimeOfEnd,
				DriverId = r.DriverId,
				Driver = new DriverViewModel
				{
					Id = r.Driver.Id,
					FirstName = r.Driver.FirstName,
					LastName = r.Driver.LastName,
					FullName = r.Driver.FullName
				},
				VehicleId = r.VehicleId,
				Mileage = r.Mileage.ToString(),
				FuelConsumption = r.FuelConsumption.ToString(),
		    });

		    return registerShiftsViewModel;
	    }

	    public async Task<ActionResult> AddRegisterShift(int vehicleId = 0)
		{
			SelectList drivers = new SelectList(await _driverService.GetDriversAsync(), "Id", "FullName");
			ViewBag.Driver = drivers;
			var registerShiftViewModel = new RegisterShiftEditViewModel
			{
				Title = "Добавление новой смены",
				AddButtonTitle = "Добавить",
				RedirectUrl = Url.Action("Index", "RegisterShift"),
				VehicleId = vehicleId
			};

			return View(registerShiftViewModel);
		}

		[HttpPost]
		public async Task<ActionResult> AddNewRegisterShift(RegisterShiftEditViewModel registerShiftViewModel, string redirectUrl)
		{
			if (!ModelState.IsValid)
			{
				return RedirectToAction("AddRegisterShift", new { vehicleId = registerShiftViewModel.VehicleId});
			}

			var registerShift = new RegisterShift
			{
				TimeOfBeginning = registerShiftViewModel.TimeOfBeginning,
				TimeOfEnd = registerShiftViewModel.TimeOfEnd,
				DriverId = registerShiftViewModel.DriverId,
				Mileage = decimal.Parse(registerShiftViewModel.Mileage, CultureInfo.InvariantCulture),
				FuelConsumption = decimal.Parse(registerShiftViewModel.FuelConsumption, CultureInfo.InvariantCulture),
				VehicleId = registerShiftViewModel.VehicleId
			};

			await _registerShiftService.AddRegisterShiftAsync(registerShift);

			return RedirectToAction("EditVehicle","Vehicle", new {id = registerShift.VehicleId});
		}

		public async Task<ActionResult> DeleteRegisterShift(int id)
		{
			var registerShift = await _registerShiftService.GetRegisterShiftAsync(id);
			var vehicleId = registerShift.VehicleId;

			await _registerShiftService.DeleteRegisterShiftAsync(id);

			return RedirectToAction("EditVehicle","Vehicle", new {id = vehicleId});
		}
	}
}