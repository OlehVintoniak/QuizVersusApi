using System;
using System.Runtime.Serialization;

namespace QuizVersus.Core.Exceptions
{
    [Serializable]
    public class CoreException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public CoreException()
        {
        }

        public CoreException(string message) : base(message)
        {
        }

        public CoreException(string message, Exception inner) : base(message, inner)
        {
        }

        protected CoreException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
