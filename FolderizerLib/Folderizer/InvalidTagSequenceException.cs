using System;
using System.Runtime.Serialization;

namespace FolderizerLib
{
    [Serializable]
    public class InvalidTagSequenceException : Exception
    {
        public InvalidTagSequenceException()
        {
        }

        public InvalidTagSequenceException(string message) : base(message)
        {
        }

        public InvalidTagSequenceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidTagSequenceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}