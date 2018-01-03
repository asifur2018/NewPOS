using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Globalization;
using System.Windows.Data;

namespace Accounts_Pos.Helpers
{
    class CheckDate : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                //CultureInfo culture = CultureInfo.CreateSpecificCulture("en-AU");
                //Convert.ToDateTime(value.ToString());
                DateTime.ParseExact(value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                return new ValidationResult(true, "Valid Date");
            }
            catch
            {
                return new ValidationResult(false, "Invalid Date");
            }
        }
    }
    class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null) return System.Convert.ToDateTime(value);
            else return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                int day; int month; int year;
                string date = value.ToString();
                try
                {
                    int.TryParse(date.Substring(0, 2), out day);
                    int.TryParse(date.Substring(3, 2), out month);
                    int.TryParse(date.Substring(6, 4), out year);
                    return new DateTime(year, month, day);
                }
                catch
                {
                    return new Exception("Please Enter Date in DD/MM/YYYY format");
                }
            }
            else
            {
                throw new Exception("Please Enter Date in DD/MM/YYYY format");
            }
        }
    }
}
