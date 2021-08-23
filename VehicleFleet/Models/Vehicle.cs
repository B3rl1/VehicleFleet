using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleFleet.Models
{
	public class Vehicle
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int EngineHP { get; set; }
		public int NewCarCost { get; set; }

		public readonly decimal ServiceRatio = 5;
		public IEnumerable<RegisterShift> RegisterShifts { get; set; }
	}
}