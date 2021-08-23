using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleFleet.ViewModels
{
	interface IViewModelInfo
	{
		string Title { get; set; }
		string AddButtonTitle { get; set; }
		string RedirectUrl { get; set; }
	}
}
