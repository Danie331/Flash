
using System;

namespace Flash.Services.Exceptions
{
    [Serializable]
    public class UserAssignmentException : Exception
    {
        public UserAssignmentException()
        {
        }

        public UserAssignmentException(string message)
            : base(message)
        {
        }

        public UserAssignmentException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
