using System;

namespace AnimationRigging
{
    public class InvalidRigConstraintToWrapException : Exception
    {
        public InvalidRigConstraintToWrapException(string message) : base(message)
        {
        }
    }
}