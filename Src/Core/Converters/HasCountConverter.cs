﻿using System.Globalization;
using CommunityToolkit.Maui.Converters;

namespace SistemaPOS.Src.Core.Converters;

public class HasCountConverter : BaseConverterOneWay<int, bool>
{
    public override bool DefaultConvertReturnValue { get; set; } = false;

    public override bool ConvertFrom(int value, CultureInfo? culture)
    {
        return value > 0;
    }
}