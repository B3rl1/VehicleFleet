using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Runtime.CompilerServices;
using VehicleFleet.Models;
using VehicleFleet.ViewModels.DriverViewModels;

namespace VehicleFleet.ViewModels.RegisterShiftViewModels
{
	public class CorrectDecimalStringAttribute : ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			var str = value.ToString();

			decimal num = decimal.Parse(str, CultureInfo.InvariantCulture);

			if (num < 1.0m || num > 9999.9m)
				return false;

			return true;
		}
	}

	public class RegisterShiftViewModel
	{
		public int Id { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = "Дата начала смены")]
		[DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
		public DateTime TimeOfBeginning { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = "Дата окончания смены")]
		[DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
		public DateTime TimeOfEnd { get; set; }

		[Display(Name = "Водитель")]
		public DriverViewModel Driver { get; set; }

		[Display(Name = "Пройденное расстояние")]
		[CorrectDecimalString(ErrorMessage = "Число должно быть в диапозоне от 1 до 9999.9")]
		[DataType(DataType.Text)]
		[Required(ErrorMessage = ("Поле \"Пройденное расстояние\" не должно быть пустым."))]
		[RegularExpression("[+-]?([0-9]*[.])?[0-9]+", ErrorMessage = "Число должно быть таким: 123.949")]
		public string Mileage { get; set; }

		[Display(Name = "Расход топлива")]
		[CorrectDecimalString(ErrorMessage = "Число должно быть в диапозоне от 1 до 9999.9")]
		[DataType(DataType.Text)]
		[Required(ErrorMessage = ("Поле \"Расход топлива\" не должно быть пустым."))]
		[RegularExpression("[+-]?([0-9]*[.])?[0-9]+", ErrorMessage = "Число должно быть таким: 123.949")]
		public string FuelConsumption { get; set; }
		public int DriverId { get; set; }
		public int VehicleId { get; set; }
	}
}