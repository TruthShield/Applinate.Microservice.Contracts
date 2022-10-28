// Copyright (c) TruthShield, LLC. All rights reserved.
namespace Applinate
{
    public sealed class FormattedString:IEquatable<FormattedString>
    {
        public FormattedString(string value, int formatId) : this(value, Format.FromId(formatId)) { }

        public FormattedString(string value, Format format = null)
        {
            Value = value;
            Format = format ?? Format.Text;
        }

        public string Value { get; }
        public Format Format { get; }

        public static readonly FormattedString Empty = new(string.Empty);

        public override string ToString() => Value;

        public override bool Equals(object? obj) => 
            Equals(obj as FormattedString);

        public override int GetHashCode() => 
            Value.GetHashCode(StringComparison.Ordinal) ^ Format.GetHashCode();

        public bool Equals(FormattedString? other) => 
            other is not null && 
            string.Equals(Value, other.Value, StringComparison.Ordinal) && 
            Format == other.Format;

        public static bool operator !=(FormattedString a, FormattedString b) => 
            !(a == b);

        public static bool operator ==(FormattedString a, FormattedString b) => 
            ReferenceEquals(a, b) || 
            (a is not null && a.Equals(b));
    }

}