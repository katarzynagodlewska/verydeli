using System;

namespace VeryDeli.Data.Data
{
    public class LogicException : Exception
    {
        public LogicErrorCode ErrorCode { get; private set; } = LogicErrorCode.DefaultError;

        public LogicException(string message) : base(message)
        {
        }

        public LogicException(LogicErrorCode errorCode, string errorMessage) : base(errorMessage)
        {
            ErrorCode = errorCode;
        }
    }
}
