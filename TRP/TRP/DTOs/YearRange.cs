using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TRP.DTOs
{
    public class YearRange : ValidationAttribute
    {
        private readonly int _minYear;

        public YearRange(int minYear)
        {
            _minYear = minYear;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Year is required.");
            }

            if (value is int year)
            {
                int currentYear = DateTime.Now.Year;
                if (year >= _minYear && year <= currentYear)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult($"Year must be between {_minYear} and {currentYear}.");
                }
            }

            return new ValidationResult("Invalid year format.");
        }
    }
}