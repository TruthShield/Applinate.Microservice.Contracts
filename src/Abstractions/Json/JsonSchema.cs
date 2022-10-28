// Copyright (c) TruthShield, LLC. All rights reserved.
namespace Applinate
{
    public sealed class JsonSchema
    {
        public static readonly JsonSchema Empty = new(string.Empty, FormattedString.Empty, new(0,0,0), Json.Empty);

        public JsonSchema(
            string name,
            FormattedString description,
            Version version,
            Json json)
        {
            Name = name;
            Description = description;
            Version = version;
            Json = json;
        }

        public FormattedString Description { get; }
        public string Name { get; }
        public Json Json { get; }
        public Version Version { get; }
    }
}