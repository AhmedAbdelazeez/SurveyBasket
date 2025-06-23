using System.ComponentModel.DataAnnotations;

namespace SurveyBasket.Api.Validation
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class MinAgeAttribute(int minAge) : ValidationAttribute
    {
        private readonly int _minAge = minAge;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not null)
            {
                var date = (DateTime)value;
                if (DateTime.Today < date.AddYears(_minAge))
                {
                    return new ValidationResult(errorMessage: $"Invalid {validationContext.DisplayName} should be {_minAge} years old ");
                }
            }

            return ValidationResult.Success;

        }

    }
}
