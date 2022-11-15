// Copyright (c) TruthShield, LLC. All rights reserved.
namespace Applinate
{
    /// <summary>
    /// Lookup class used to find commands and queries.
    /// </summary>
    /// <example>Build.A().ContentManager().AdministrationCommand()</example>
    public static class Build
    {
        private static readonly Builder _A = new();

        /// <summary>
        /// Gets a manager, engine, or access command or query.
        /// </summary>
        /// <value>a.</value>
        public static Builder A() => _A;
    }
}