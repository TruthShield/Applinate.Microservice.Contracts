// Copyright (c) TruthShield, LLC. All rights reserved.
namespace Applinate
{
    using NJsonSchema.Validation;
    using System;

    public static class JsonExtensions
    {
        public static async Task< IEnumerable<JsonValidationError>> ValidateAsync(this Json json, JsonSchema schema, CancellationToken cancellation = default)
        {
            throw new NotImplementedException("need to set up tests");

            var validator = await NJsonSchema.JsonSchema.FromJsonAsync(schema.Json.Value, cancellation).ConfigureAwait(false);
            var errors = validator.Validate(json.Value);

            var result = errors.Select(Map).ToArray();

            return result;
        }

        private static JsonValidationError Map(ValidationError arg) => new(
                arg.Property,
                arg.HasLineInfo,
                arg.LinePosition,
                arg.Kind.ToString(),
                arg.LineNumber,
                arg.Path,
                arg.Schema.Title);

        public static Task<IEnumerable<JsonValidationError>> ValidateAsync(this JsonSchema schema, Json json) => 
            json.ValidateAsync(schema);
    }
}