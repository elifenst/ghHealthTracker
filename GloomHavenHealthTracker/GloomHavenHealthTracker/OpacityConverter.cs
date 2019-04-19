using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace GloomHavenHealthTracker
{
    class OpacityConverter:IValueConverter
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
}
