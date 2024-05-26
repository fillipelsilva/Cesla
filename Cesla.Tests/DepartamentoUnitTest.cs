using AutoMapper;
using Cesla.Application.AppServices;
using Cesla.Application.Commands.DepartamentoCommand;
using Cesla.Application.Queries.Interfaces;
using Cesla.Application.ViewModels.DepartamentoViewModels;
using Cesla.Domain.Entities;
using Core.Communication.MediatrHandler;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Tests
{
    public class DepartamentoUnitTest : IClassFixture<DepartamentoFixture>
    {
        private readonly Mock<IDepartamentoQueries> _departamentoQueriesMock;
        private readonly Mock<IMediatorHandler> _mediatorHandlerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly DepartamentoAppService _departamentoAppService;

        public DepartamentoUnitTest()
        {
            _departamentoQueriesMock = new Mock<IDepartamentoQueries>();
            _mediatorHandlerMock = new Mock<IMediatorHandler>();
            _mapperMock = new Mock<IMapper>();
            _departamentoAppService = new DepartamentoAppService(_departamentoQueriesMock.Object, _mediatorHandlerMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task ListarDepartamentos_Deve_Retornar_Lista_De_Departamentos()
        {
            // Arrange
            var departamentosEsperados = new List<DepartamentoQueryResultViewModel>
        {
            new DepartamentoQueryResultViewModel { Id = 1, Nome = "Departamento 1" },
            new DepartamentoQueryResultViewModel { Id = 2, Nome = "Departamento 2" }
        };

            _departamentoQueriesMock.Setup(x => x.ListarDepartamentos()).ReturnsAsync(departamentosEsperados);

            // Act
            var result = await _departamentoAppService.ListarDepartamentos();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(departamentosEsperados.Count, result.Count);
            Assert.Equal(departamentosEsperados[0].Nome, result[0].Nome);
            Assert.Equal(departamentosEsperados[1].Nome, result[1].Nome);
        }

        [Fact]
        public async Task CadastrarDepartamento_Deve_Retornar_True_Quando_Cadastro_Sucesso()
        {
            // Arrange
            var departamentoViewModel = new DepartamentoInsertViewModel { Nome = "Novo Departamento" };

            _mapperMock.Setup(x => x.Map<Departamento>(It.IsAny<DepartamentoInsertViewModel>())).Returns(new Departamento());
            _mediatorHandlerMock.Setup(x => x.EnviarComando(It.IsAny<AdicionarDepartamentoCommand>())).ReturnsAsync(true);

            // Act
            var result = await _departamentoAppService.CadastrarDepartamento(departamentoViewModel);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task AtualizarDepartamento_Deve_Retornar_True_Quando_Atualizacao_Sucesso()
        {
            // Arrange
            var departamentoViewModel = new DepartamentoUpdateViewModel { Id = 1, Nome = "Novo Nome" };

            _mapperMock.Setup(x => x.Map<Departamento>(It.IsAny<DepartamentoUpdateViewModel>())).Returns(new Departamento());
            _mediatorHandlerMock.Setup(x => x.EnviarComando(It.IsAny<AtualizarDepartamentoCommand>())).ReturnsAsync(true);

            // Act
            var result = await _departamentoAppService.AtualizarDepartamento(departamentoViewModel);

            // Assert
            Assert.True(result);
        }
    }

}
