using System;
using System.Runtime.Serialization;

namespace App.BLL
{
    [Serializable]
    public class LinkAlreadyExistException:Exception
    {
        public LinkAlreadyExistException()
        {

        }

        public LinkAlreadyExistException(string message) : base(message)
        {
        }

        public LinkAlreadyExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected LinkAlreadyExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
