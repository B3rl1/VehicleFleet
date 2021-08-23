using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleFleet.ViewModels.VehicleViewModels
{
	public class VehicleEditViewModel : VehicleViewModel, IViewModelInfo
	{
		public string Title { get; set; }
		public string AddButtonTitle { get; set; }
		public string RedirectUrl { get; set; }
		public Dictionary<string, string> ResidualValueByYear { get; set; } = new Dictionary<string, string>();
	}
}