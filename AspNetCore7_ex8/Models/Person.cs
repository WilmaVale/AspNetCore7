using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore7_ex8.Models
{
    public class Person
    {
        //[Required]// non può essere null o vuota nella request
        //[Required(ErrorMessage = "Person name can't be empty or null")] // aggiungi un messaggio
        [Required(ErrorMessage = "{0} can't be empty or null")] // semplifica il messaggio stesso, {0} diventa "Person name" grazie a Display
        [Display(Name = "Person name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} should be between {2} and {1} ")]
        [RegularExpression("^[A-Za-z .]", ErrorMessage ="{0} should contain only alphabets, space and dot (.)")]
        public string? PersonName { get; set; }

        [EmailAddress(ErrorMessage = "{0} should be a proper email")]
        [Required(ErrorMessage = "{0} can't be empty or null")]
        public string? Email { get; set; }

        [Phone(ErrorMessage ="{0} should be a proper phone number")]
        [ValidateNever]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "{0} can't be empty or null")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "{0} can't be empty or null")]
        [Compare("Password", ErrorMessage ="{0} should be equal to the password {1}")]
        [Display(Name ="Re-enter password")]
        public string? ConfirmPassword { get; set; }

        [Range(0, 999.99, ErrorMessage ="{0} should be between {1} and {2}")]
        public double? Price { get; set; }

        public override string ToString()
        {
            return $"Person object - Name: {PersonName}, " +
                $"email: {Email}, phone: {Phone}, password: {Password}, " +
                $"confirm password: {ConfirmPassword}, price: {Price}";
        }

    }
}
