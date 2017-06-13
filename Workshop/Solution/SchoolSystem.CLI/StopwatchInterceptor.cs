using Ninject.Extensions.Interception;
using SchoolSystem.Framework.Core.Contracts;
using System.Diagnostics;

namespace SchoolSystem.Cli
{
    public class StopwatchInterceptor : IInterceptor
    {
        private readonly IWriter writer;

        public StopwatchInterceptor(IWriter writer)
        {
            this.writer = writer;
        }

        public void Intercept(IInvocation invocation)
        {
            Stopwatch stopwatch = new Stopwatch();
            string methodName = invocation.Request.Method.Name;
            string methodType = invocation.Request.Method.DeclaringType.Name;

            writer.WriteLine($"Calling method {methodName} of type {methodType}");

            stopwatch.Start();
            invocation.Proceed();
            stopwatch.Stop();

            writer.WriteLine($"Total execution time for method {methodName} of type {methodType} is {stopwatch.ElapsedMilliseconds} milliseconds.");
        }
    }
}
