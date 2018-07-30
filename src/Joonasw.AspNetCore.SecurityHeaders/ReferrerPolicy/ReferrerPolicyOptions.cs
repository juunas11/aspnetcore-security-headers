﻿using System.ComponentModel;

namespace Joonasw.AspNetCore.SecurityHeaders.ReferrerPolicy
{
    public class ReferrerPolicyOptions
    {
        public ReferrerPolicyOptions()
        {
            
        }

        /// <summary>
        /// Defined the parameters for the Referrer Policy header sent in the response to the client
        /// </summary>
        /// <param name="value">The value to be applied to the Referrer Policy header</param>
        public ReferrerPolicyOptions(ReferrerPolicyValues value)
        {
            ReferrerPolicyValue = value;
        }

        /// <summary>
        /// Gets the referrer policy value to be applied to the ReferrerPolicy header
        /// no-referrer is set by default
        /// </summary>
        public ReferrerPolicyValues ReferrerPolicyValue { get; set; } = ReferrerPolicyValues.NoReferrer;

        public enum ReferrerPolicyValues
        {
            [DefaultValue("")]
            None = 0,
            [DefaultValue("no-referrer")]
            NoReferrer = 1,
            [DefaultValue("no-referrer-when-downgrade")]
            NoReferrerWhenDowngrade = 2,
            [DefaultValue("same-origin")]
            SameOrigin = 3,
            [DefaultValue("origin")]
            Origin = 4,
            [DefaultValue("strict-origin")]
            StrictOrigin = 5,
            [DefaultValue("origin-when-cross-origin")]
            OriginWhenCrossOrigin = 6,
            [DefaultValue("strict-origin-when-cross-origin")]
            StrictOriginWhenCrossOrigin = 7,
            [DefaultValue("unsafe-url")]
            UnsafeUrl = 8
        }
    }
}
