// Copyright (c) TruthShield, LLC. All rights reserved.
namespace Applinate
{
    public static class ServiceClinetExtensions
    {
        public static Builder BuildA(this ServiceClient c)  {

            RequestContext.Current = c.Context;

            return new ();
        }
    }
}