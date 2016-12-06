﻿using System;
using System.Runtime.Serialization;

namespace App.BLL
{
    /// <summary>
    /// Exception handling class
    /// </summary>
    [Serializable]
    public class EventAlreadyExistException : Exception
    {
        #region Constructors
        /// <summary>
        /// Empty constructor to inicialize class
        /// </summary>
        public EventAlreadyExistException()
        {

        }
        /// <summary>
        /// Constructor catch a message exception
        /// </summary>
        /// <param name="message">Message about error</param>
        public EventAlreadyExistException(string message) : base(message)
        {
        }
        /// <summary>
        /// Constructor catch a message exception and a inner exception
        /// </summary>
        /// <param name="message">Message about error</param>
        /// <param name="innerException">Message about inner exception</param>
        public EventAlreadyExistException(string message, Exception innerException) : base(message, innerException)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected EventAlreadyExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        #endregion
    }
}
