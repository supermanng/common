using System;

namespace Etechnosoft.Common.Data
{
    [AttributeUsage(AttributeTargets.Field)]
    sealed class MessageAttribute : Attribute
    {
        public string Message { get; }

        public MessageAttribute(string message)
        {
            Message = message;
        }
    }
}