using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
namespace BlackRose
{
    class DurationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            FullTrack fullTrack = (FullTrack)value;
            if(fullTrack != null && fullTrack.Player.NaturalDuration.HasTimeSpan)
            return fullTrack.Player.NaturalDuration.TimeSpan.Seconds;
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
