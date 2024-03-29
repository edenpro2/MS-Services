﻿using System;
using System.Windows.Data;

namespace PL.Converters;

public class StatusConverter : IValueConverter
{
    public object? Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        return (value.ToString() == "Stopped") ? "" : value.ToString();
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
