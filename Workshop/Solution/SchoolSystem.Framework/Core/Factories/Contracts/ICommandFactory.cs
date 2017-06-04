using SchoolSystem.Framework.Core.Commands.Contracts;
using System;

namespace SchoolSystem.Framework.Core.Factories.Contracts
{
    public interface ICommandFactory
    {
        ICommand GetCommand(string fullCommand);
    }
}
