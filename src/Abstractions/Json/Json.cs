// Copyright (c) TruthShield, LLC. All rights reserved.
namespace Applinate
{
    using System;

    public sealed class Json : IEquatable<Json>, IEquatable<string> // TODO: factor into FormattedString and remvoe this class
    {
        public Json(string value = null)
        {
            Value = value ?? string.Empty;
        }

        public static readonly Json Empty = new();
        public string Value { get; }

        public static Result<T> Deserialize<T>(Json data) =>
            new(Newtonsoft.Json.JsonConvert.DeserializeObject<T>(data.Value), true, Array.Empty<string>());

        public static Result<Json> Serialize<T>(T arg)
        {
            return new Result<Json>(new(Newtonsoft.Json.JsonConvert.SerializeObject(arg)), true, Array.Empty<string>());
        }

        public bool Equals(string? other)
        {
            if (other is null) return false;

            return Value.Equals(other, StringComparison.Ordinal);
        }

        public bool Equals(Json? other)
        {
            if (other is null) return false;

            return Value.Equals(other.Value, StringComparison.Ordinal);
        }

        public override bool Equals(object? obj)
        {
            if (obj is string) return Equals(obj as string);
            return Equals(obj as Json);
        }

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => Value;

        public static bool operator ==(Json a, Json b)
        {
            if (ReferenceEquals(a, b)) return true;

            if (a is null) { return false; }


            return a.Equals(b);
        }

        public static bool operator !=(Json a, Json b) => !(a == b);
    }
}