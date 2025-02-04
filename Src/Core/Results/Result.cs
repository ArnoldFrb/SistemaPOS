namespace SistemaPOS.Src.Core.Results
{
    public class Result<T, E>
    {
        private readonly T _value;
        private readonly E _error;

        private Result(T value)
        {
            _value = value;
            _error = default!;
        }

        private Result(E error)
        {
            _value = default!;
            _error = error;
        }

        public static Result<T, E> Ok(T value) => new(value);
        public static Result<T, E> Error(E error) => new(error);

        public bool IsOkOrError => _value != null && _error == null;

        public T Unwrap() => _value;
        public E UnwrapError() => _error;
    }
}
