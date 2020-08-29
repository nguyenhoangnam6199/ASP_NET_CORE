using System;
using System.ComponentModel.DataAnnotations;

namespace Buoi9_ASP.Models
{
    internal class BirthDateCheckAttribute : ValidationAttribute
    {
        public BirthDateCheckAttribute(string errorMessage="") : base(errorMessage)
        {

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var myDate = DateTime.Parse(value.ToString());
            if (myDate > DateTime.Now)
            {
                return new ValidationResult("Ngày sinh trong tương lai !");
            }
            return ValidationResult.Success;
        }


    }
}