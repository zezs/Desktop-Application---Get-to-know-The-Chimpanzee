using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApp_Chimpanzee
{
    public class String2ImagePath : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return $"/Gallery/11.jpg";
            }
            else
            {
                if (File.Exists(value.ToString()))
                {
                    return value;
                }
                else
                {
                    return $"/Gallery/11.jpg";
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class Int2String : IValueConverter 
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch((int)value)
            {
                case 0: return "Female";
                case 1: return "Male";
                case 2: return "Diverse";
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((string)value)
            {
                case "Female": return 0;
                case "Male": return 1;
                case "Diverse": return 2;
            }
            return null;
        }
    }
}
