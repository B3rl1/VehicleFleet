namespace VehicleFleet.ViewModels.DriverViewModels
{
	public class DriverEditViewModel : DriverViewModel, IViewModelInfo
	{
		public string Title { get; set; }
		public string AddButtonTitle { get; set; }
		public string RedirectUrl { get; set; }
	}
}