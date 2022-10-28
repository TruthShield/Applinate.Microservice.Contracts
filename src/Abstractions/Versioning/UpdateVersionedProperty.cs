// Copyright (c) TruthShield, LLC. All rights reserved.
namespace Applinate
{
    [Serializable]
    public class UpgradeVersion<T>
    {
        public Version FromVersion { get; }
        public VersionIncrement VersionUpdateType { get; }
        public T? Value { get; }

        public static readonly UpgradeVersion<T> Empty = new UpgradeVersion<T>(new(0, 0), VersionIncrement.Unknown, default);

        public UpgradeVersion(Version fromVersion, VersionIncrement versionUpdateType, T? newValue)
        {
            FromVersion = fromVersion;
            VersionUpdateType = versionUpdateType;
            Value = newValue;
        }
    }

}