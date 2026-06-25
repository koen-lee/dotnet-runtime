// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.ComponentModel;

namespace System.Text.RegularExpressions
{
    /// <summary>Creates a <see cref="RegexRunner"/> for a <see cref="Regex"/>.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class RegexRunnerFactory
    {
        /// <summary>Initializes a new instance of the <see cref="RegexRunnerFactory"/> class.</summary>
        protected RegexRunnerFactory() { }

        /// <summary>Creates a <see cref="RegexRunner"/> instance for the <see cref="Regex"/>.</summary>
        /// <returns>A <see cref="RegexRunner"/> instance.</returns>
        protected internal abstract RegexRunner CreateInstance();

        /// <summary>
        /// True if this factory implements its own runner rental via <see cref="RentRunner"/>/<see cref="ReturnRunner"/>
        /// and <see cref="Regex"/> should defer to them instead of caching a runner itself.
        /// </summary>
        /// <remarks>
        /// Handles backwards compatibility for existing RegexRunnerFactory implementations that don't implement runner rental.
        /// </remarks>
        protected internal virtual bool SupportsRunnerRental => false;

        /// <summary>Rents a runner from this factory's own cache (allocating if none cached). Only called when <see cref="SupportsRunnerRental"/> is true.</summary>
        protected internal virtual RegexRunner RentRunner() => CreateInstance();

        /// <summary>Returns a runner to this factory's own cache. Only called when <see cref="SupportsRunnerRental"/> is true.</summary>
        protected internal virtual void ReturnRunner(RegexRunner runner) { }
    }
}
