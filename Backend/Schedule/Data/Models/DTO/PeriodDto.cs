using System.ComponentModel.DataAnnotations;

namespace Schedule.Data.Models.DTO
{
    public class PeriodDto
    {
        //[DateLessThan("DateFrom", ErrorMessage = "DateTo must be later than DateFrom")]
        [Range(typeof(DateTime), "2022-09-01T00:01:01.001Z", "2025-01-01T00:01:01.000Z",
            ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime DateTo { get; set; }

        [Range(typeof(DateTime), "2022-09-01T00:01:01.001Z", "2025-01-01T00:01:01.000Z",
            ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime DateFrom { get; set; }
    }

    public class DateLessThanAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public DateLessThanAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;
            var currentValue = (DateTime)value;

            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (property == null)
                throw new ArgumentException("Property with this name not found");

            var comparisonValue = (DateTime)property.GetValue(validationContext.ObjectInstance);

            if (currentValue > comparisonValue)
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }
    }
}
