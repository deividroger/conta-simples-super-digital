using ContaSimples.BusinessCore.Entities;

namespace ContaSimples.BusinessCore.Interfaces
{
    public interface ITransacoesService
    {
        void TransferirEntreContas(Cliente cliente, int agenciaOrigem, int contaOrigem, int agenciaDestino, int contaDestino, decimal valor);
    }
}