using ContaSimples.BusinessCore.Entities;
using ContaSimples.BusinessCore.Interfaces;
using ContaSimples.BusinessCore.Services;
using Moq;
using System;
using Xunit;

namespace ContaSimples.BusinessTest
{
    public class UnitContaCorrente
    {
        [Fact(DisplayName = "Deve retornar a conta corrente")]
        public void Deve_Retornar_ContaCorrente()
        {
            // arrange

            var contaCorrente = new ContaCorrente()
            {
                Agencia = 9104,
                Conta = 01550
            };

            var mock = new Mock<IContaCorrenteRepository>();
            mock.Setup(m => m.Obtem(1234)).Returns(contaCorrente);

            var contaCorrenteService = new ContaCorrenteService(mock.Object);

            // act
            var contaCorrenteEsperada = contaCorrenteService.Obtem(1234);
            // assert  
            Assert.Equal(contaCorrenteEsperada, contaCorrente);
        }

        [Fact(DisplayName = "Deve retornar conta corrente não encontrada")]
        public void Deve_Retornar_ContaCorrente_Nao_Encontrada()
        {
            // arrange
            var contaCorrente = new ContaCorrente()
            {
                Agencia = 9104,
                Conta = 01550
            };

            var mock = new Mock<IContaCorrenteRepository>();
            mock.Setup(m => m.Obtem(9104)).Returns(contaCorrente);

            var contaCorrenteService = new ContaCorrenteService(mock.Object);

            // act
            var ex = Assert.Throws<Exception>(() => contaCorrenteService.Obtem(9105));

            // assert  
            Assert.Equal("Conta corrente não encontrada", ex.Message);
        }

        [Fact(DisplayName = "Deve dizer que a conta corrente existe")]
        public void Deve_Dizer_Que_ContaCorrente_Existe()
        {
            // arrange
            var contaCorrente = new ContaCorrente()
            {
                Agencia = 9104,
                Conta = 01550
            };

            var mock = new Mock<IContaCorrenteRepository>();
            mock.Setup(m => m.Obtem(9104, 01550)).Returns(contaCorrente);

            var contaCorrenteService = new ContaCorrenteService(mock.Object);

            // act
            var existe = contaCorrenteService.ContaCorrenteExiste(9104, 01550);

            // assert  
            Assert.True(existe);
        }

        [Fact(DisplayName = "Deve dizer que a conta corrente não existe")]
        public void Deve_Dizer_Que_ContaCorrente_Nao_Existe()
        {
            // arrange
            var contaCorrente = new ContaCorrente()
            {
                Agencia = 9104,
                Conta = 01550            };

            var mock = new Mock<IContaCorrenteRepository>();
            mock.Setup(m => m.Obtem(9104, 01550)).Returns(contaCorrente);

            var contaCorrenteService = new ContaCorrenteService(mock.Object);

            // act
            var existe = contaCorrenteService.ContaCorrenteExiste(9101, 01550);

            // assert  
            Assert.False(existe);
        }

        [Fact(DisplayName = "Posso realizar debito da conta")]
        public void ContaCorrente_Pode_Realizar_Debito()
        {
            // arrange
            var contaCorrente = new ContaCorrente()
            {
                Agencia = 9104,
                Conta = 01550
            };

            var mock = new Mock<IContaCorrenteRepository>();
            mock.Setup(m => m.Obtem(1234)).Returns(contaCorrente);

            var contaCorrenteService = new ContaCorrenteService(mock.Object);

            // act
            var contaCorrenteObtida = contaCorrenteService.Obtem(1234);
            var valorSolicitado = 200;

            // assert  
            Assert.True(contaCorrenteObtida.PossoDebitar(valorSolicitado));
        }

        [Fact(DisplayName = "Não posso realizar debito da conta")]
        public void ContaCorrente_Nao_Pode_Realizar_Debito()
        {
            // arrange
            var contaCorrente = new ContaCorrente()
            {
                Agencia = 9104,
                Conta = 01550
            };

            var mock = new Mock<IContaCorrenteRepository>();
            mock.Setup(m => m.Obtem(1234)).Returns(contaCorrente);

            var contaCorrenteService = new ContaCorrenteService(mock.Object);

            // act
            var contaCorrenteObtida = contaCorrenteService.Obtem(1234);
            var valorSolicitado = 100001;

            // assert  
            Assert.False(contaCorrenteObtida.PossoDebitar(valorSolicitado));
        }
    }
}