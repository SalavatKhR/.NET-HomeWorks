using System;

namespace hw11.ExceptionHandler
{

        public interface IExceptionHandler
        {
            void HandleException<T>(T exception) where T : Exception;
        }

        public interface IExceptionHandler<T> where T : Exception
        {
            void Handle(T exception);
        }

}