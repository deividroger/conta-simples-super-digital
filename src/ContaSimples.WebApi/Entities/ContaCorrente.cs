using System.Collections.Generic;
using System.Linq;

namespace ContaSimples.BusinessCore.Entities
{
    public class ContaCorrente : EntityBase
    {
        public int Agencia { get; set; }

        public int Conta { get; set; }

        public Cliente Cliente { get; set; }
       
        public decimal Saldo { get; set; }

        public bool EMesmaConta(ContaCorrente contaCorrente)
        =>  contaCorrente.Id == this.Id
                   && contaCorrente.Agencia == this.Agencia
                   && contaCorrente.Conta == this.Conta;

        public bool PossoDebitar(decimal valorSolicitado)
            => Saldo >= valorSolicitado;

 


    }
}