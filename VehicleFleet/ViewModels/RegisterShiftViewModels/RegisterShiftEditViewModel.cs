using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleFleet.ViewModels.RegisterShiftViewModels
{
	public class RegisterShiftEditViewModel : RegisterShiftViewModel, IViewModelInfo
	{
		public string Title { get; set; }
		public string AddButtonTitle { get; set; }
		public string RedirectUrl { get; set; }
	}
}