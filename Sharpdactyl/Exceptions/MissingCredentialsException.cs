using System;

namespace SharpdactylLib.Exceptions
{
    /// <summary>
    /// Represents errors that occur during application execution.
    /// </summary>
    public class MissingCredentialsException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MissingCredentialsException" /> class with a specified error message.
        /// </summary>
        /// <param name="message">the error message</param>
        public MissingCredentialsException(string message) : base(message)
        {}

        /// <summary>
        /// Initializes a new instance of the <see cref="MissingCredentialsException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">the error message</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (<see langword="Nothing" /> in Visual Basic) if no inner exception is specified. </param>
        public MissingCredentialsException(string message, Exception innerException) : base(message, innerException)
        {}
    }
}
