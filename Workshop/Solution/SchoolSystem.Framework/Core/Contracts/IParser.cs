using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;

namespace SchoolSystem.Framework.Core.Contracts
{
    /// <summary>
    /// Interface for a Parser provider
    /// </summary>
    public interface IParser
    {
        /// <summary>
        /// Parses the parameters of a command.
        /// </summary>
        /// <param name="fullCommand">The command to parse.</param>
        /// <returns>Returns an IList<string> collection of parameters.</returns>
        IList<string> ParseParameters(string fullCommand);
    }
}
