// Copyright (c) TruthShield, LLC. All rights reserved.
namespace Applinate
{
    public static class DoExtensions
    {
        public static void Do<T>(this Do<T> d, Action<T> func)
        {
            if (d.Execute)
            {
                func(d.Value);
            }
        }

        public static U MapOr<T, U>(this Do<T> value, Func<T, U> f, U fallback) =>
            value.Execute ? f(value.Value) : fallback;

        public static T Or<T>(this Do<T> value, T fallback) =>
            (value.Execute && value.Value is not null) ? value.Value : fallback;

        public static FormattedString OrEmpty(this Do<FormattedString> value) =>
           value.Execute ? value.Value ?? FormattedString.Empty : FormattedString.Empty;

        public static string OrEmpty(this Do<string> value) =>
            value.Execute ? value.Value ?? String.Empty : string.Empty;

        public static T? OrNull<T>(this Do<T> value) where T : class =>
            value.Execute ? value.Value : null;

        public static T OrThrow<T>(this Do<T> value, string errorMessage) =>
            value.Execute ? value.Value : throw new InvalidOperationException(errorMessage);
    }

    [Serializable]
    public class Do<T>
    {
        public static readonly Do<T> Nothing = new(default, false);

        private const string NOOP = "no-op";

        public Do(T? value, bool execute = true)
        {
            Execute = execute;
            Value = value;
        }

        public bool Execute { get; }
        public T? Value { get; }

        public static implicit operator Do<T>(T value) => new(value);

        public override string ToString() => Execute ? Value?.ToString() ?? NOOP : NOOP;
    }
}