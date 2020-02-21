using ContaSimples.BusinessCore.Entities;
using ContaSimples.BusinessCore.Interfaces;
using ContaSimples.WebApi.CustomErrors;
using ContaSimples.WebApi.Dto;
using ContaSimples.WebApi.Infra;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ContaSimples.WebApi.Controllers
{

    [Route("api/[controller]")]
    public class ContaCorrenteController : ControllerBase
    {
        private readonly ITransacoesService _transacoesService;

        public ContaCorrenteController(ITransacoesService transacoesService)
        {
            _transacoesService = transacoesService;
        }

        [HttpPost]
        [Route("transferir")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400, Type = typeof(object))]
        [ProducesResponseType(403, Type = typeof(string))]
        [ProducesResponseType(200, Type = typeof(string))]
        public ObjectResult Transferir([FromBody] TransferenciaDto dadosTransferencia)
        {
            if (!ModelState.IsValid) return BadRequest(dadosTransferencia);

            var cliente = ClienteTokenService.ClienteFromToken(dadosTransferencia.AccessToken);

            if (cliente == null) return Unauthorized("");

            if (DadosDaTransferenciaSaoIguais(dadosTransferencia)) return BadRequest("A conta de origem e destino não podem ser iguais");

            return RealizaTransferencia(dadosTransferencia, cliente);
        }

        private ObjectResult RealizaTransferencia(TransferenciaDto dadosTransferencia, Cliente cliente)
        {
            try
            {
                _transacoesService.TransferirEntreContas(cliente, dadosTransferencia.Origem.Agencia, dadosTransferencia.Origem.Conta,
                                                                    dadosTransferencia.Destino.Agencia, dadosTransferencia.Destino.Conta, dadosTransferencia.Valor);

                return Ok("Transferência realizada com sucesso");
            }
            catch (TransferenciaCustomException ex)
            {
                return StatusCode(403, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }

        private static bool DadosDaTransferenciaSaoIguais(TransferenciaDto dadosTransferencia)
        {
            return dadosTransferencia.Origem.Agencia == dadosTransferencia.Destino.Agencia &&
                           dadosTransferencia.Origem.Conta == dadosTransferencia.Destino.Conta;
        }

    }
}