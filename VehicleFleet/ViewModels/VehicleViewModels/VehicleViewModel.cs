using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VehicleFleet.Models;
using VehicleFleet.ViewModels.RegisterShiftViewModels;

namespace VehicleFleet.ViewModels.VehicleViewModels
{
	public class VehicleViewModel
	{
		public int Id { get; set; }

		[Display(Name = "Название машины")]
		[Required(ErrorMessage = ("Поле \"Название машины\" не должно быть пустым"))]
		[StringLength(30, MinimumLength = 5)]
		public string Name { get; set; }

		[Display(Name = "Мощность двигателя, л.с.")]
		[Required(ErrorMessage = ("Поле \"Мощность двигателя, л.с.\" не должно быть пустым"))]
		[Range(50, 1499)]
		public int EngineHP { get; set; }

		[Display(Name = "Стоимость нового автомобиля, руб.")]
		[Required(ErrorMessage = ("Поле \"Стоимость нового автомобиля, л.с.\" не должно быть пустым"))]
		[Range(500000, 30000000)]
		public int NewCarCost { get; set; }

		[Display(Name = "Общее пройденное расстояние")]
		public string MileageSum { get; set; }

		[Display(Name = "Общее расходование топлива")]
		public string FuelConsumptionSum { get; set; }
		public decimal ServiceRatio { get; set; }

		[Display(Name = "Остаточная стоимость")]
		[DisplayFormat(DataFormatString = "{0:f2}")]
		public decimal ResidualValue { get; set; }
		public IEnumerable<RegisterShiftViewModel> RegisterShifts { get; set; }
	}
}