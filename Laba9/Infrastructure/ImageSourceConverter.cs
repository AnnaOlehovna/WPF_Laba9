using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace Laba9.Infrastructure
{
    class ImageSourceConverter : IValueConverter
    {
        string imageDirectory = Directory.GetCurrentDirectory();
        string ImageDirectory
        {
            get
            {
                return Path.Combine(imageDirectory, "images");
            }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value !=null)
            {
                return Path.Combine(ImageDirectory, (string)value);
            }
            else
            {
                return Path.Combine(ImageDirectory, "no_photo.jpg");
            }
            
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
