using System;
using System.Runtime.Serialization;

namespace Exemple.Domain
{
    [Serializable]
    internal class InvalidPretException : Exception
    {
        public InvalidPretException()
        {
        }

        public InvalidPretException(string? message) : base(message)
        {
        }

        public InvalidPretException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidPretException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}