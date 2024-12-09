﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace JokesApp.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Adres email")]
        [Required(ErrorMessage = "Adres email jest wymagany")]
        public string EmailAddress { get; set; }
        [Display(Name = "Hasło")]
        [Required(ErrorMessage = "Hasło jest wymagane")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
