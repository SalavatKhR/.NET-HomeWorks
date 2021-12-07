using System;

namespace hw11.ExceptionHandler
{
    public interface IExceptionHandler
    {
        public void Handle(Exception e);
        void Aggregate(Exception exception);
    }
    
}