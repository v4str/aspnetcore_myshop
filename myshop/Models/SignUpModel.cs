using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace myshop.Models
{
    public class SignUpModel
    {
        [Required(ErrorMessage = "Пожалуйста, введите свой email")]
        [Display(Name = "Email адрес")]
        [EmailAddress(ErrorMessage = "Пожалуйста, введите корректный email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите пароль")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Пожалуйста, подтвердите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [Display(Name = "Подтвердите пароль")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
