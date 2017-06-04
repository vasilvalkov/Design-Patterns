using Ninject;
using Ninject.Modules;
using SchoolSystem.Cli.Configuration;
using SchoolSystem.CLI;
using SchoolSystem.Framework.Core;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Factories;
using SchoolSystem.Framework.Core.Factories.Contracts;
using SchoolSystem.Framework.Core.Providers;

namespace SchoolSystem.Cli
{
    public class SchoolSystemModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IReader>().To<ConsoleReaderProvider>();
            this.Bind<IWriter>().To<ConsoleWriterProvider>();
            this.Bind<IParser>().To<CommandParserProvider>();

            this.Bind<ISchoolFactory>().To<SchoolFactory>().InSingletonScope();
            this.Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();
            this.Bind<ISchoolDatabase>().To<SchoolDatabase>().InSingletonScope();            

            this.Bind<IEngine>().To<Engine>().InSingletonScope();
            this.Bind<IServiceLocator>().To<ServiceLocator>();

            this.Bind<IConfigurationProvider>().To<ConfigurationProvider>();
            
            IConfigurationProvider configurationProvider = Kernel.Get<IConfigurationProvider>();
            if (configurationProvider.IsTestEnvironment)
            {
            }
        }
    }
}