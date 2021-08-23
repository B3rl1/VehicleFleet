using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace VehicleFleet.Models
{
	public class RegisterShift
	{
		public int Id { get; set; }
		public DateTime TimeOfBeginning { get; set; }
		public DateTime TimeOfEnd { get; set; }
		public decimal Mileage { get; set; }
		public decimal FuelConsumption { get; set; }

		public int DriverId { get; set; }
		public Driver Driver { get; set; }

		public int VehicleId { get; set; }
		public Vehicle Vehicle { get; set; }
	}
}