using ContaSimples.BusinessCore.Entities;
using ContaSimples.BusinessCore.Interfaces;

namespace ContaSimples.BusinessCore.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
            => _clienteRepository = clienteRepository;

        public Cliente Obtem(string documento, string email)
            => _clienteRepository.ObtemCliente(documento, email);

    }
}