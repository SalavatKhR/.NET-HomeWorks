using System;
using Microsoft.Extensions.Logging;

namespace hw11.ExceptionHandler
{
    public class ExceptionHandler: IExceptionHandler
    {
        private ILogger Logger;

        public ExceptionHandler(ILogger logger)
        {
            Logger = logger;
        }

        public void Aggregate(Exception e)
        {
            Handle((dynamic) e);
        }
        
        public void Handle(Exception e)
        {
            Logger.LogError($"Unidentified exception {e}");
        }

        public void Handle(ArgumentNullException e)
        {
            Logger.LogError($"ArgumentNullException");
        }

        public void Handle(DivideByZeroException e)
        {
            Logger.LogError($"DivideByZeroException");
        }

        public void Handle(InvalidOperationException e)
        {
            Logger.LogError($"InvalidOperationException");
        }
    }
}