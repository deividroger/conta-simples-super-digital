using System;

namespace ContaSimples.BusinessCore.Entities
{
    public class Lancamento:EntityBase
    {

        public ContaCorrente ContaCorrente { get; set; }

        public string Descricao { get; set; }

        public TipoLancamento TipoLancamento { get; set; }

        public decimal Valor { get; set; }

        public DateTime Data { get; set; }
    }
}