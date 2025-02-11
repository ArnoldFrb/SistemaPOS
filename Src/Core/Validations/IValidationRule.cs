﻿namespace SistemaPOS.Src.Core.Validations
{
    public interface IValidationRule<T>
    {
        string ValidationMessage { get; set; }

        bool Check(T value);
    }
}