using System;
using Xamarin.Forms;

namespace GloomHavenHealthTracker
{
    class ButtonEnabledConverter:IValueConverter
    {
		public double True { get; set; }

		public double False { get; set; }

		public object Convert(object value, Type targetType,
	object parameter, System.Globalization.CultureInfo culture)
		{
			if (value == null)
			{
				return False;
			}
			if (value.GetType() != typeof(bool))
			{
				return False;
			}
			return ((bool)value) ? True : False;
		}
		public object ConvertBack(object value,
			Type targetType,
			object parameter,
			System.Globalization.CultureInfo culture)
		{
			return value;
		}
	}
	class ButtonOnConverter : IValueConverter
	{
		public string Checked { get; set; }

		public string Unchecked { get; set; }

		public object Convert(object value, Type targetType,
	object parameter, System.Globalization.CultureInfo culture)
		{
			if (value == null)
			{
				return Unchecked;
			}
			if (value.GetType() != typeof(int))
			{
				return Unchecked;
			}
			return ((int)value==1) ? Checked : Unchecked;
		}
		public object ConvertBack(object value,
			Type targetType,
			object parameter,
			System.Globalization.CultureInfo culture)
		{
			return value;
		}
	}
}