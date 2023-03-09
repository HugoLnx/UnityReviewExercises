using System;
using System.Runtime.Serialization;

namespace ReviewNewInputSystem
{
    [Serializable]
    public class ConditionMonitorWithTimeoutNeedIncrement : Exception
    {
        public ConditionMonitorWithTimeoutNeedIncrement()
        {
        }

        public ConditionMonitorWithTimeoutNeedIncrement(string message) : base(message)
        {
        }

        public ConditionMonitorWithTimeoutNeedIncrement(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ConditionMonitorWithTimeoutNeedIncrement(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}