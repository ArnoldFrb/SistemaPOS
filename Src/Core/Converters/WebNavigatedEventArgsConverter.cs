﻿using System.Globalization;
using CommunityToolkit.Maui.Converters;

namespace SistemaPOS.Src.Core.Converters;

public class WebNavigatedEventArgsConverter : BaseConverterOneWay<WebNavigatedEventArgs, string>
{
    public override string DefaultConvertReturnValue { get; set; } = string.Empty;

    public override string ConvertFrom(WebNavigatedEventArgs value, CultureInfo? culture)
    {
        return value?.Url ?? string.Empty;
    }
}