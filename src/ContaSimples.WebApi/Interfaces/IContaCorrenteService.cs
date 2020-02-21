using ContaSimples.BusinessCore.Entities;

namespace ContaSimples.BusinessCore.Interfaces
{
    public interface IContaCorrenteService
    {
        ContaCorrente Obtem(int codigoCliente);

        ContaCorrente Obtem(int agencia, int numeroContaCorrente);

        bool ContaCorrenteExiste(int agencia, int numeroContaCorrente);
    }
}