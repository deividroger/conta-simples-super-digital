using ContaSimples.BusinessCore.Entities;
using ContaSimples.BusinessCore.Interfaces;
using ContaSimples.WebApi.CustomErrors;
using System;
using System.Collections.Generic;

namespace ContaSimples.BusinessCore.Services
{
    public class TransacoesService : ITransacoesService
    {
        private readonly IContaCorrenteService _contaCorrenteService;
        private readonly IContaCorrenteRepository _contaCorrenteRepository;

        public TransacoesService(IContaCorrenteService contaCorrenteService,
                                 IContaCorrenteRepository contaCorrenteRepository)
        {
            _contaCorrenteService = contaCorrenteService;
            _contaCorrenteRepository = contaCorrenteRepository;
        }

        public void TransferirEntreContas(Cliente cliente, int agenciaOrigem,int contaOrigem, int agenciaDestino,int contaDestino, decimal valor)

        {
            var contaCorrenteOrigem = _contaCorrenteService.Obtem(agenciaOrigem, contaOrigem);
            var contaCorrenteDestino = _contaCorrenteService.Obtem(agenciaDestino, contaDestino);

            if(contaCorrenteOrigem.Cliente.Id != cliente.Id) throw new TransferenciaCustomException("A conta de origem não pertece a cliente");

            if (contaCorrenteOrigem.Id == contaCorrenteDestino.Id) throw new TransferenciaCustomException("Conta de origem e destino não podem ser iguais");
            
            if (contaCorrenteOrigem == null) throw new TransferenciaCustomException("Conta corrente de origem inexistente");
            if (contaCorrenteDestino == null) throw new TransferenciaCustomException("Conta corrente de destino inexistente");


            if (!contaCorrenteOrigem.PossoDebitar(valor)) throw new TransferenciaCustomException("Saldo em conta corrente indisponivel");

            var lancamentos = CriaListaDeLancamentosDebitoCredito(valor, contaCorrenteOrigem, contaCorrenteDestino);

            _contaCorrenteRepository.GravarLancamentos(lancamentos);
        }

        private static List<Lancamento> CriaListaDeLancamentosDebitoCredito(decimal valor, ContaCorrente contaCorrenteOrigem, ContaCorrente contaDestino)
        {
            var lancamentos = new List<Lancamento>();

            var lancamentoDebito = new Lancamento()
            {
                Data = DateTime.Now,
                Descricao = "Transferência entre contas - débito",
                TipoLancamento = TipoLancamento.DEBITO,
                Valor = valor * -1,
                ContaCorrente = contaCorrenteOrigem
            };

            var lancamentoCredito = new Lancamento()
            {
                Data = DateTime.Now,
                Descricao = "Transferência entre contas - crédito",
                TipoLancamento = TipoLancamento.CREDITO,
                Valor = valor,
                ContaCorrente = contaDestino
            };

            lancamentos.Add(lancamentoDebito);
            lancamentos.Add(lancamentoCredito);

            return lancamentos;
        }
    }
}
