using CommunityToolkit.Mvvm.ComponentModel;

namespace SistemaPOS.Src.Core.Validations
{
    public class ValidatableObject<T> : ObservableObject, IValidity
    {
        private IEnumerable<string> _errors;
        private bool _isValid;
        private T? _value;

        public List<IValidationRule<T>> Validations { get; } = [];

        public IEnumerable<string> Errors
        {
            get => _errors;
            private set => SetProperty(ref _errors, value);
        }

        public bool IsValid
        {
            get => _isValid;
            private set => SetProperty(ref _isValid, value);
        }

        public T? Value
        {
            get => _value;
            set => SetProperty(ref _value, value);
        }

        public ValidatableObject()
        {
            _isValid = true;
            _errors = [];
        }

        public T? GetValue()
        {
            return Value;
        }

        public bool Validate(T? value)
        {
            Errors = Validations
                ?.Where(v => !v.Check(value!))
                ?.Select(v => v.ValidationMessage)
                ?.ToArray()
                ?? Enumerable.Empty<string>();

            IsValid = !Errors.Any();

            return IsValid;
        }
    }
}
