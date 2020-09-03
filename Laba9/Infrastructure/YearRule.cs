using System;
using System.Globalization;
using System.Windows.Controls;

namespace Laba9.Infrastructure
{
    class YearRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double convertedValue;

            try
            {
                convertedValue = Double.Parse((string)value, new NumberFormatInfo());
            }
            catch
            {
                return new ValidationResult(false, "Недопустимые символы. Год должен быть числом");
            }

            if (convertedValue < 1885)
            {
                return new ValidationResult(false, "Машину изобрели в 1885");
            }
            return ValidationResult.ValidResult;
        }
    }
}
