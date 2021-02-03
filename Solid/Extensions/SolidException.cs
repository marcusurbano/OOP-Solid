using System;
using System.Runtime.Serialization;

namespace Solid.Extensions
{
    public class SolidException : Exception
    {
        public SolidException(string message) : base(message)
        {
        }
    }
}
