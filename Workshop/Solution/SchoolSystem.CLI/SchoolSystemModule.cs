using Ninject;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;
using SchoolSystem.Cli.Configuration;
using SchoolSystem.CLI;
using SchoolSystem.Framework.Core;
using SchoolSystem.Framework.Core.Commands;
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

            var schoolFactoryBinding = this.Bind<ISchoolFactory>().To<SchoolFactory>().InSingletonScope();
            var commandFactoryBinding = this.Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();
            this.Bind<ISchoolDatabase>().To<SchoolDatabase>().InSingletonScope();

            this.Bind<CreateStudentCommand>().ToSelf().InSingletonScope();        
            this.Bind<CreateTeacherCommand>().ToSelf().InSingletonScope();

            this.Bind<IEngine>().To<Engine>().InSingletonScope();
            this.Bind<IServiceLocator>().To<ServiceLocator>();

            this.Bind<IConfigurationProvider>().To<ConfigurationProvider>();
            
            IConfigurationProvider configurationProvider = Kernel.Get<IConfigurationProvider>();
            if (configurationProvider.IsTestEnvironment)
            {
                commandFactoryBinding.Intercept().With<StopwatchInterceptor>();
                schoolFactoryBinding.Intercept().With<StopwatchInterceptor>();
            }
        }
    }
}