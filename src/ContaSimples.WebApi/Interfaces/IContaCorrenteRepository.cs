using ContaSimples.BusinessCore.Entities;
using System;
using System.Collections.Generic;

namespace ContaSimples.BusinessCore.Interfaces
{
    public interface IContaCorrenteRepository
    {
        ContaCorrente Obtem(int codigoCliente);
        ContaCorrente Obtem(long agencia, long contaCorrente);

        void GravarLancamentos(IEnumerable<Lancamento> lancamentos);
    }
}