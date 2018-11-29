using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace TestEntityFramework.Model
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value is byte[])
            {
                byte[] bytes = value as byte[];
                //using (var stream = new MemoryStream(bytes))
                //{
                    var stream = new MemoryStream(bytes);
                    var image = new BitmapImage();
                    image.BeginInit();
                    image.StreamSource = stream;
                    image.EndInit();

                    return image;
                //}                
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //throw new Exception("The method or operation is not implemented.");
            if(value != null && value is string)
            {
                string imageFilePath = value as string;
                byte[] bytes = File.ReadAllBytes(imageFilePath);

                return bytes;
            }

            return null;
        }
    }
}