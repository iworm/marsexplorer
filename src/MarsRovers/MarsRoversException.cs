using System;

namespace MarsRovers
{
    public class MarsRoversException : Exception
    {
        private readonly string _message;

        public MarsRoversException()
        {
        }

        public MarsRoversException(string message)
        {
            _message = message;
        }

        public override string Message
        {
            get { return _message; }
        }
    }
}