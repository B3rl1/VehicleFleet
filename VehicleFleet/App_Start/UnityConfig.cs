using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Injection;
using VehicleFleet.Controllers;
using VehicleFleet.Models;
using VehicleFleet.Repository;
using VehicleFleet.Repository.DriverRepositories;
using VehicleFleet.Repository.RegisterShiftRepositories;
using VehicleFleet.Repository.VehicleRepositories;
using VehicleFleet.Services.DriverServices;
using VehicleFleet.Services.RegisterShiftServices;

namespace VehicleFleet.App_Start
{
	public class UnityConfig
	{
		public static IUnityContainer Initialize()
		{
			var container = BuildUnityContainer();
			DependencyResolver.SetResolver(new UnityDependencyResolver(container));
			return container;
		}

		private static IUnityContainer BuildUnityContainer()
		{
			var container = new UnityContainer();

			container.RegisterType<IVehicleRepository, VehicleRepository>();
			container.RegisterType<IVehicleService, VehicleService>();
			container.RegisterType<IDriverRepository, DriverRepository>();
			container.RegisterType<IDriverService, DriverService>();
			container.RegisterType<IRegisterShiftRepository, RegisterShiftRepository>();
			container.RegisterType<IRegisterShiftService, RegisterShiftService>();

			return container;
		}
	}
}