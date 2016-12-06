using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL
{
    /// <summary>
    /// Exception handling class
    /// </summary>
    [Serializable]
    public class BenefitAlreadyExistException:Exception
    {
        #region Constructors
        /// <summary>
        /// Empty constructor to inicialize class
        /// </summary>
        public BenefitAlreadyExistException()
        {

        }
        /// <summary>
        /// Constructor catch a message exception
        /// </summary>
        /// <param name="message">Message about error</param>
        public BenefitAlreadyExistException(string message) : base(message)
        {
        }
        /// <summary>
        /// Constructor catch a message exception and a inner exception
        /// </summary>
        /// <param name="message">Message about error</param>
        /// <param name="innerException">Message about inner exception</param>
        public BenefitAlreadyExistException(string message, Exception innerException) : base(message, innerException)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected BenefitAlreadyExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        #endregion
    }
}
