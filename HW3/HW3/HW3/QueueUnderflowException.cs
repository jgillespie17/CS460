using System;


namespace HW3
{
    [Serializable]
    internal class QueueUnderflowException : Exception
    {
        public QueueUnderflowException()
        {
        }

        public QueueUnderflowException(string message) : base(message)
        {
        }

    }
}