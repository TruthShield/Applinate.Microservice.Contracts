// Copyright (c) TruthShield, LLC. All rights reserved.
namespace Applinate
{
    using Applinate.Internals;
    public static class ServiceClientExtensions
    {
        public static Builder BuildA(this ServiceClient c) 
        {
            c.Context.SetCurrentRequestContext();
            return new ();
        }
    }
}