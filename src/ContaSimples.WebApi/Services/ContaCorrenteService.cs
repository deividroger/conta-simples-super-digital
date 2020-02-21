using ContaSimples.BusinessCore.Entities;
using ContaSimples.BusinessCore.Interfaces;

namespace ContaSimples.BusinessCore.Services
{
    public class ContaCorrenteService : IContaCorrenteService
    {
        private readonly IContaCorrenteRepository _contaCorrenteRepository;

        public ContaCorrenteService(IContaCorrenteRepository contaCorrenteRepository)
            => _contaCorrenteRepository = contaCorrenteRepository;
        
        public ContaCorrente Obtem(int codigoCliente)
        {
            var _contaCorrente = _contaCorrenteRepository.Obtem(codigoCliente);

            TrataContaCorrenteNaoEncontrada(_contaCorrente);

            return _contaCorrente;
        }

        public ContaCorrente Obtem(int agencia,int contaCorrente)
        {
            var _contaCorrente = _contaCorrenteRepository.Obtem(agencia, contaCorrente);

            TrataContaCorrenteNaoEncontrada(_contaCorrente);


            return _contaCorrente;
        }

        public bool ContaCorrenteExiste(int agencia, int numeroContaCorrente)
        {
            var contaCorrente = _contaCorrenteRepository.Obtem(agencia, numeroContaCorrente);

            if (contaCorrente == null) return false;

            return true;
                
        }

        private static void TrataContaCorrenteNaoEncontrada(ContaCorrente _contaCorrente)
        {
            if (_contaCorrente == null) throw new System.Exception("Conta corrente não encontrada");
        }
    }
}