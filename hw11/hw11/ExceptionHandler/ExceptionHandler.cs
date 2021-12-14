using System;
using Microsoft.Extensions.Logging;

namespace hw11.ExceptionHandler
{
    public class ExceptionHandler: IExceptionHandler,
        IExceptionHandler<ArgumentNullException>,
        IExceptionHandler<DivideByZeroException>,
        IExceptionHandler<InvalidOperationException>
    {
        private ILogger Logger;

        public ExceptionHandler(ILogger logger)
        {
            Logger = logger;
        }

        public void HandleException<T>(T exception) where T : Exception
        {
            var handler = this as IExceptionHandler<T>;
            if(handler != null)
                handler.Handle(exception);
            else
                this.Handle(exception as dynamic);
        }
        
        public void Handle(Exception exception)
        {
            OnFallback(exception);
        }

        protected virtual void OnFallback(Exception exception)
        {
            Logger.LogError($"Unidentified exception {exception}");
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