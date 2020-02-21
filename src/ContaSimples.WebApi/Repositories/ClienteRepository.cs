using ContaSimples.BusinessCore.Entities;
using ContaSimples.BusinessCore.Interfaces;
using ContaSimples.BusinessCore.Repositories;
using System.Linq;

namespace ContaSimples.BusinessCore.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ContaCorrenteContext _contaCorrenteContext;

        public ClienteRepository(ContaCorrenteContext contaCorrenteContext)
            => _contaCorrenteContext = contaCorrenteContext;

        public Cliente ObtemCliente(string documento, string email)
          => _contaCorrenteContext
                      .Clientes.Where(x => x.Documento == documento && x.Email == email)
                      .SingleOrDefault();

    }
}

