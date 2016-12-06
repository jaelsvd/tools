using System;
using System.Runtime.Serialization;

namespace App.BLL
{
    [Serializable]
    public class PolicyAlreadyExistException : Exception
    {
        public PolicyAlreadyExistException()
        {
        }

        public PolicyAlreadyExistException(string message) : base(message)
        {
        }

        public PolicyAlreadyExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PolicyAlreadyExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}