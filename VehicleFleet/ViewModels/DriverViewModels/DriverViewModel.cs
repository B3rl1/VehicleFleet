using System.ComponentModel.DataAnnotations;

namespace VehicleFleet.ViewModels.DriverViewModels
{
	public class DriverViewModel
	{
	public int Id { get; set; }

	[Display(Name = "Имя водителя")]
	[Required(ErrorMessage = ("Поле \"имя водителя\" не должно быть пустым."))]
	[RegularExpression("^((([А-Я]{1})|([а-я]){1})[а-яё]{1,23}|(([A-Z]{1})|([a-z]){1})[a-z]{1,23})$", ErrorMessage = "Имя должно быть длинной от 2 до 24 символов. Пример: Егор")]
	public string FirstName { get; set; }

	[Display(Name = "Фамилия водителя")]
	[Required(ErrorMessage = ("Поле \"фамилия водителя\" не должно быть пустым."))]
	[RegularExpression("^((([А-Я]{1})|([а-я]){1})[а-яё]{1,23}|(([A-Z]{1})|([a-z]){1})[a-z]{1,23})$", ErrorMessage = "Фамилия должна быть длинной от 2 до 24 символов. Пример: Петров")]
	public string LastName { get; set; }

	[Display(Name = "Ф.И.")] 
	public string FullName { get; set; }
	}
}