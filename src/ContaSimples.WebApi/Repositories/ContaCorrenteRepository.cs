using ContaSimples.BusinessCore.Entities;
using ContaSimples.BusinessCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContaSimples.BusinessCore.Repositories
{
    public class ContaCorrenteRepository : IContaCorrenteRepository
    {
        private readonly ContaCorrenteContext _contaCorrenteContext;

        public ContaCorrenteRepository(ContaCorrenteContext contaCorrenteContext)
            => _contaCorrenteContext = contaCorrenteContext;

        public ContaCorrente Obtem(int codigoCliente)
        {
            var conta = _contaCorrenteContext
                   .ContaCorrente
                   .Include("Cliente")
                   .Where(x => x.Cliente.Id == codigoCliente)
                   .SingleOrDefault();

            CarregaDetalhesDaConta(conta);


            return conta;
        }

        public ContaCorrente Obtem(long agencia, long contaCorrente)
        {
            
            var conta = _contaCorrenteContext
                    .ContaCorrente
                    .Include("Cliente")
                    .Where(x => x.Agencia == agencia
                                     && x.Conta == contaCorrente)
                    
                    .SingleOrDefault();

          

            CarregaDetalhesDaConta(conta);

            return conta;

        }

        private void CarregaDetalhesDaConta(ContaCorrente conta)
        {
            if (conta != null)
            {

                conta.Saldo = _contaCorrenteContext
                                    .Lancamentos
                                    .Where(x => x.ContaCorrente == conta)
                                    .Sum(x => x.Valor);

              

            }
        }

        public void GravarLancamentos(IEnumerable<Lancamento> lancamentos)
        {
            try
            {
                _contaCorrenteContext
                        .Lancamentos
                        .AddRange(lancamentos);

                _contaCorrenteContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
