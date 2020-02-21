using System;
namespace ContaSimples.WebApi.CustomErrors
{
    public class TransferenciaCustomException : Exception
    {
        public TransferenciaCustomException(string error):base(error)
        {

        }
    }
}
