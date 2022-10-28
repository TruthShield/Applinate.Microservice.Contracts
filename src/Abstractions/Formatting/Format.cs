// Copyright (c) TruthShield, LLC. All rights reserved.
namespace Applinate
{
    using System.Collections.Immutable;

    public sealed class Format : IEquatable<Format>
    {
        private const int TextId = 0;
        private const int MarkdownId = 10;
        private const int JsonId = 20;
        private const int HtmlId = 30;
        private const int XmlId = 40;

        public static readonly Format Text = new(TextId, "");
        public static readonly Format Markdown = new(MarkdownId, "md");
        public static readonly Format Json = new(JsonId, "json");
        public static readonly Format Html = new(HtmlId, "html");
        public static readonly Format Xml = new(XmlId, "xml");

        private static readonly Lazy<ImmutableDictionary<int, Format>> _KnownFormats =
            new Lazy<ImmutableDictionary<int, Format>>(BuildLookup);

        private static ImmutableDictionary<int, Format> BuildLookup() =>
        new Dictionary<int, Format>()
        {
            { Format.Text.Id, Format.Text } ,
            // TODO: WORK HERE
        }.ToImmutableDictionary();

        public Format(int id) : this(id, _KnownFormats.Value.TryGetValue(id, out var val) ? val.Value : string.Empty) { }

        public Format(int id, string value)
        {
            Id = id;
            Value = value;
        }

        public int Id { get; }
        public string Value { get; }
        public static Format[] All => new[] { Text, Markdown, Json, Html, Xml }; // TODO: to lazy cached

        public override bool Equals(object? obj)
        {
            return base.Equals(obj as Format);
        }

        public override string ToString()
        {
            return Value;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public static bool operator ==(Format a, Format b) => ReferenceEquals(a, b) || a.Equals(b);

        public static bool operator !=(Format a, Format b) => !(a == b);

        public bool Equals(Format? other) => other is not null && Id == other.Id;

        public static implicit operator int(Format a) => a.Id;

        public static Format FromId(int detailFormatId)
        {
            switch(detailFormatId)
            {
                case TextId: return Text;
                case MarkdownId: return Markdown;
                case JsonId: return Json;
                case HtmlId: return Html;
                case XmlId: return Xml;
                default: throw new KeyNotFoundException($"format not found with id {detailFormatId} ");
            }
        }
    }

}