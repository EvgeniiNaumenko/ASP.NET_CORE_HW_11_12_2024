using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1_HW_11_12_2024.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Имя обязательно для заполнения.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Фамилия обязательна для заполнения.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Имя пользователя обязательно для заполнения.")]
        [StringLength(20, ErrorMessage = "Имя пользователя не должно превышать 20 символов.")]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Имя пользователя может содержать только буквы, цифры и символ подчеркивания.")]
        [Remote(action: "CheckUsername", controller: "Account", ErrorMessage = "Это имя пользователя уже занято.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Пароль обязателен для заполнения.")]
        [StringLength(100, ErrorMessage = "Пароль не должен превышать 100 символов.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Подтверждение пароля обязательно.")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Электронная почта обязательна для заполнения.")]
        [EmailAddress(ErrorMessage = "Некорректный формат электронной почты.")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Некорректный формат номера телефона.")]
        public string PhoneNumber { get; set; }

        [Range(18, 100, ErrorMessage = "Возраст должен быть в пределах от 18 до 100 лет.")]
        public int? Age { get; set; }

        [CreditCard(ErrorMessage = "Некорректный номер кредитной карты.")]
        public string CreditCardNumber { get; set; }

        [Url(ErrorMessage = "Некорректный формат URL-адреса.")]
        public string Website { get; set; }

        [ValidateNever]
        public bool TermsOfService { get; set; }
    }
}
