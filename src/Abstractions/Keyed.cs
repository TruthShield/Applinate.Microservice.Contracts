// Copyright (c) TruthShield, LLC. All rights reserved.
namespace Applinate
{
    using System.Diagnostics;

    [DebuggerDisplay("{Key}")]
    public abstract class Keyed:IEquatable<Keyed>, IEquatable<string>
    {
        protected Keyed(string key)
        {
            Key = key;
        }

        public string Key { get; }

        public bool Equals(Keyed? other) =>
            ReferenceEquals(other, this) ||
            (
                other is not null &&
                other.GetType() == GetType() &&
                other.Key.Equals(Key, StringComparison.Ordinal)
            );

        public override bool Equals(object? obj) => Equals(obj as Keyed);
        public override int GetHashCode() => Key.GetHashCode();

        public bool Equals(string? other) => other is not null && other.Equals(Key);

        public static implicit operator string(Keyed a) => a.Key;

        public static bool operator ==(Keyed a, Keyed b) => a is not null && a.Equals(b);
        public static bool operator !=(Keyed a, Keyed b) => !(a == b);

        public static bool operator ==(string a, Keyed b) => b is not null && b.Equals(a);
        public static bool operator !=(string a, Keyed b) => !(a == b);

        public static bool operator ==(Keyed a, string b) => a is not null && a.Equals(b);
        public static bool operator !=(Keyed a, string b) => !(a == b);
    }
}