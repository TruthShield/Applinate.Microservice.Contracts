// Copyright (c) TruthShield, LLC. All rights reserved.
namespace Applinate
{
    public static class VersionExtensions
    {
        public static Version Increment(this Version v, VersionIncrement increment)
        {
            switch (increment)
            {
                case VersionIncrement.Major:
                    return new Version(v.Major + 1, 0, 0);
                case VersionIncrement.Minor:
                    return new Version(v.Major, v.Minor + 1, 0);
                case VersionIncrement.Patch:
                    return new Version(v.Major, v.Minor, v.Build + 1);

                default: throw new InvalidOperationException("unsupported increment type: " + increment);
            }
        }

    }
}