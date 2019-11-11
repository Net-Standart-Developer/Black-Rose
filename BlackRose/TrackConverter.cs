using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace BlackRose
{
    class TrackConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((FullTrack)value).Track;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
