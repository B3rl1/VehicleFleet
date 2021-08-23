using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VehicleFleet.Models;

namespace VehicleFleet
{
	public class VehicleFleetContext : DbContext
	{
		public VehicleFleetContext() : base("DefaultConnection")
		{
			
		}

		public DbSet<Vehicle> Vehicles { get; set; }
		public DbSet<Driver> Drivers { get; set; }
		public DbSet<RegisterShift> RegisterShifts { get; set; }
	}
}