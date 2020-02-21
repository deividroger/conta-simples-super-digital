using ContaSimples.BusinessCore.Entities;

namespace ContaSimples.BusinessCore.Interfaces
{
    public interface IClienteService
    {
        Cliente Obtem(string documento, string email);
    }
}