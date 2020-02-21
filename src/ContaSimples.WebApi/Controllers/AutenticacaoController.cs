using ContaSimples.BusinessCore.Interfaces;
using ContaSimples.WebApi.Dto;
using ContaSimples.WebApi.Infra;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ContaSimples.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public AutenticacaoController(IClienteService clienteService)
            => _clienteService = clienteService;


        [HttpPost("Autenticar")]
       public ObjectResult CreateAccessToken([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid) return BadRequest(usuario);

            try
            {
                var cliente = _clienteService.Obtem(usuario.Documento, usuario.Email);

                if (cliente == null) return NotFound("Cliente não faz parte do banco");

                var token = ClienteTokenService.GenerateTokenFromCliente(cliente);

                return Ok( token);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
                throw;
            }
        }
    }
}