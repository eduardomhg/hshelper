using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using Hearthstone;

namespace HearthstoneHelper
{
    [ValueConversion(typeof(List<CardMechanics>), typeof(string))]
    class CardMechanicsListToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string text = String.Empty;
            List<CardMechanics> mechanics = value as List<CardMechanics>;

            foreach (CardMechanics m in mechanics)
            {
                text = text + m.ToString() + ", ";
            }

            if (text != String.Empty)
            {
                text = text.Substring(0, text.Length - 2);
            }

            return text;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
