using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VehicleFleet.Models;
using VehicleFleet.Services.DriverServices;
using VehicleFleet.ViewModels;
using VehicleFleet.ViewModels.DriverViewModels;

namespace VehicleFleet.Controllers
{
    public class DriverController : Controller
    {
	    private readonly IDriverService _driverService;

	    public DriverController(IDriverService driverService)
	    {
		    _driverService = driverService;
	    }

        public async Task<ActionResult> Index()
        {
	        var drivers = await _driverService.GetDriversAsync();

	        var driversViewModel = drivers.Select(dr => new DriverViewModel
	        {
				Id = dr.Id,
				FirstName = dr.FirstName,
				LastName = dr.LastName,
				FullName = dr.FullName
	        });
           
	        return View(driversViewModel);
        }

        public ActionResult AddDriver()
        {
	        var driverViewModel = new DriverEditViewModel
	        {
		        Title = "Добавление нового водителя",
		        AddButtonTitle = "Добавить",
		        RedirectUrl = Url.Action("Index", "Driver")
	        };

	        return View(driverViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> AddNewDriver(DriverEditViewModel driverViewModel, string redirectUrl)
        {
	        if (!ModelState.IsValid)
	        {
		        return RedirectToAction("AddDriver");
	        }

	        var driver = new Driver
	        {
		        FirstName = driverViewModel.FirstName,
		        LastName = driverViewModel.LastName,
		        FullName = driverViewModel.FirstName + " " + driverViewModel.LastName
	        };

	        await _driverService.AddDriverAsync(driver);

	        return RedirectToAction("Index");
        }

		public async Task<ActionResult> DeleteDriver(int id)
		{
			await _driverService.DeleteDriverAsync(id);

			return RedirectToAction("Index");
		}
	}
}