// Copyright (c) TruthShield, LLC. All rights reserved.
namespace Applinate
{
    public static class Do
    {
        public static Do<T> Nothing<T>() => new(default, false);

        public static Do<T> Set<T>(T value) => new(value, true);

        public static UpgradeVersion<T> Upgrade<T>(Version from, VersionIncrement increment, T newValue) => new(from, increment, newValue);
    }
}