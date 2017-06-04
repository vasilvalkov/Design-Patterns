using Ninject;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using System;

namespace SchoolSystem.CLI
{
    public class ServiceLocator : IServiceLocator
    {
        private readonly IKernel kernel;

        public ServiceLocator(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public ICommand GetCommand(Type commandType)
        {
            return (ICommand)this.kernel.Get(commandType);
        }
    }
}
