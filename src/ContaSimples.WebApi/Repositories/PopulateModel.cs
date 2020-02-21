using ContaSimples.BusinessCore.Entities;
using ContaSimples.BusinessCore.Repositories;
using System;
using System.Linq;

namespace ContaSimples.WebApi.Repositories
{
    public class PopulateModel
    {
        public static void SeedContext(ContaCorrenteContext context)
        {

           
            if (context.Lancamentos.Any()) return;


            var cliente1 = new Cliente()
            {
                Nome = "Fernando",
                Documento = "73364644080",
                Email = "fernando@ig.com.br"
            };

            var cliente2 = new Cliente()
            {
                Nome = "Jefferson",
                Documento = "83037585005",
                Email = "jefferson@uol.com.br"
            };

            var contaCorrente1 = new ContaCorrente()
            {
                Agencia = 1725,
                Conta = 5412,
                Cliente = cliente1
            };

            context.ContaCorrente.Add(contaCorrente1);

            var contaCorrente2 = new ContaCorrente()
            {
                Agencia = 1725,
                Conta = 54131,
                Cliente = cliente2
            };

            context.ContaCorrente.Add(contaCorrente2);

            context.Lancamentos.Add(new Lancamento()
            {
                ContaCorrente = contaCorrente1,
                Data = DateTime.Now,
                Descricao = "Depósito Inicial",
                TipoLancamento = TipoLancamento.CREDITO,
                Valor = 20000
            });

            context.Lancamentos.Add(new Lancamento()
            {
                ContaCorrente = contaCorrente1,
                Data = DateTime.Now,
                Descricao = "Auto Posto JK",
                TipoLancamento = TipoLancamento.DEBITO,
                Valor = -20
            });


            context.SaveChanges();
        }

    }
}
