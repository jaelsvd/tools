using System;
using System.Runtime.Serialization;


namespace App.BLL
{
    [Serializable]
    public class NewsAlreadyExistException : Exception
    {
        public NewsAlreadyExistException()
        {
        }

        public NewsAlreadyExistException(string message) : base(message)
        {
        }

        public NewsAlreadyExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NewsAlreadyExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
