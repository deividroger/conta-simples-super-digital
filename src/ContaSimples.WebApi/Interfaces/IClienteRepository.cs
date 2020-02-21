using ContaSimples.BusinessCore.Entities;

namespace ContaSimples.BusinessCore.Interfaces
{
    public interface IClienteRepository
    {
        Cliente ObtemCliente(string documento, string email);
    }
}