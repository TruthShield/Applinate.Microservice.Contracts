// Copyright (c) TruthShield, LLC. All rights reserved.
namespace Applinate
{
    public sealed class JsonValidationError
    {
        public JsonValidationError(
            string propertyName,
            bool hasLineInfo,
            int linePosition,
            string errorType,
            int lineNumber,
            string path,
            string elementWithValidationRule)
        {
            Property = propertyName;
            HasLineInfo = hasLineInfo;
            LinePosition = linePosition;
            ErrorType = errorType;
            LineNumber = lineNumber;
            Path = path;
            ElementWithValidationRule = elementWithValidationRule;
        }

        public string Property { get; }
        public bool HasLineInfo { get; }
        public int LinePosition { get; }
        public string ErrorType { get; }
        public int LineNumber { get; }
        public string Path { get; }
        public string ElementWithValidationRule { get; }
    }
}