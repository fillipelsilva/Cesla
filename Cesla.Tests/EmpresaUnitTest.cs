using AutoMapper;
using Cesla.Application.AppServices;
using Cesla.Application.Commands.EmpresaCommand;
using Cesla.Application.Queries.Interfaces;
using Cesla.Application.ViewModels.EmpresaVIewModels;
using Cesla.Application.ViewModels.EnderecoViewModels;
using Cesla.Domain.Entities;
using Core.Communication.MediatrHandler;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Tests
{
    public class EmpresaUnitTest
    {
        private readonly Mock<IEmpresaQueries> _empresaQueriesMock;
        private readonly Mock<IMediatorHandler> _mediatorHandlerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly EmpresaAppService _empresaAppService;

        public EmpresaUnitTest()
        {
            _empresaQueriesMock = new Mock<IEmpresaQueries>();
            _mediatorHandlerMock = new Mock<IMediatorHandler>();
            _mapperMock = new Mock<IMapper>();
            _empresaAppService = new EmpresaAppService(_empresaQueriesMock.Object, _mediatorHandlerMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task ListarEmpresas_Deve_Retornar_Lista_De_Empresas()
        {
            // Arrange
            var empresasEsperadas = new List<EmpresaQueryResultViewModel>
        {
            new EmpresaQueryResultViewModel { Nome = "Empresa 1" },
            new EmpresaQueryResultViewModel { Nome = "Empresa 2" }
        };

            _empresaQueriesMock.Setup(x => x.ListarEmpresas()).ReturnsAsync(empresasEsperadas);

            // Act
            var result = await _empresaAppService.ListarEmpresas();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(empresasEsperadas.Count, result.Count);
            Assert.Equal(empresasEsperadas[0].Nome, result[0].Nome);
            Assert.Equal(empresasEsperadas[1].Nome, result[1].Nome);
        }

        [Fact]
        public async Task CadastrarEmpresa_Deve_Retornar_True_Quando_Cadastro_Sucesso()
        {
            // Arrange
            var empresaViewModel = new EmpresaInsertViewModel
            {
                Nome = "Nova Empresa",
                Telefone = "123456789",
                Endereco = new EnderecoInsertViewModel
                {
                    Rua = "Rua Teste",
                    Numero = 10,
                    Cidade = "Cidade Teste",
                    Estado = "ES",
                    CEP = "12345678",
                    Pais = "Brasil"
                }
            };

            _mapperMock.Setup(x => x.Map<Empresa>(It.IsAny<EmpresaInsertViewModel>())).Returns(new Empresa());
            _mapperMock.Setup(x => x.Map<Endereco>(It.IsAny<EnderecoInsertViewModel>())).Returns(new Endereco());
            _mediatorHandlerMock.Setup(x => x.EnviarComando(It.IsAny<AdicionarEmpresaCommand>())).ReturnsAsync(true);

            // Act
            var result = await _empresaAppService.CadastrarEmpresa(empresaViewModel);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task AtualizarEmpresa_Deve_Retornar_True_Quando_Atualizacao_Sucesso()
        {
            // Arrange
            var empresaViewModel = new EmpresaUpdateViewModel
            {
                Id = 1,
                Nome = "Novo Nome",
                Telefone = "987654321",
                Endereco = new EnderecoUpdateViewModel
                {
                    Rua = "Nova Rua",
                    Numero = 20,
                    Cidade = "Nova Cidade",
                    Estado = "SP",
                    CEP = "98765432",
                    Pais = "Brasil"
                }
            };

            _mapperMock.Setup(x => x.Map<Empresa>(It.IsAny<EmpresaUpdateViewModel>())).Returns(new Empresa());
            _mapperMock.Setup(x => x.Map<Endereco>(It.IsAny<EnderecoUpdateViewModel>())).Returns(new Endereco());
            _mediatorHandlerMock.Setup(x => x.EnviarComando(It.IsAny<AtualizarEmpresaCommand>())).ReturnsAsync(true);

            // Act
            var result = await _empresaAppService.AtualizarEmpresa(empresaViewModel);

            // Assert
            Assert.True(result);
        }
    }
}
