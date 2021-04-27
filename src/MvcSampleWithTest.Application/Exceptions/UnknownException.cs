namespace MvcSampleWithTest.Application.Exceptions
{
    using System;

    public sealed class UnknownException : Exception
    {
        public UnknownException(string message, Exception exception = default) :
            base(message, exception)
        { }
    }
}
