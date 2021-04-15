using System;

namespace ShopFacil.Bradesco.Core.Exceptions
{
    public class BoletoException : Exception
    {
        public BoletoException() { }

        public BoletoException(string message) : base(message) { }

        public BoletoException(string message, Exception innerException) : base(message, innerException) { }
    }
}
