using AutoMapper;
using Cesla.Application.AppServices;
using Cesla.Application.Commands.ColaboradorCommand;
using Cesla.Application.Queries.Interfaces;
using Cesla.Application.ViewModels.ColaboradorViewModels;
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
    public class ColaboradorUnitTest
    {
        private readonly Mock<IColaboradoresQueries> _colaboradorQueriesMock;
        private readonly Mock<IMediatorHandler> _mediatorHandlerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ColaboradoresAppService _colaboradorAppService;

        public ColaboradorUnitTest()
        {
            _colaboradorQueriesMock = new Mock<IColaboradoresQueries>();
            _mediatorHandlerMock = new Mock<IMediatorHandler>();
            _mapperMock = new Mock<IMapper>();
            _colaboradorAppService = new ColaboradoresAppService(_colaboradorQueriesMock.Object, _mediatorHandlerMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task ListarColaboradores_Deve_Retornar_Lista_De_Colaboradores()
        {
            // Arrange
            var colaboradoresEsperados = new List<ColaboradorQueryResultViewModel>
        {
            new ColaboradorQueryResultViewModel { Id = 1, Nome = "Colaborador 1" },
            new ColaboradorQueryResultViewModel { Id = 2, Nome = "Colaborador 2" }
        };

            _colaboradorQueriesMock.Setup(x => x.ListarColaboradores()).ReturnsAsync(colaboradoresEsperados);

            // Act
            var result = await _colaboradorAppService.ListarColaboradores();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(colaboradoresEsperados.Count, result.Count);
            Assert.Equal(colaboradoresEsperados[0].Nome, result[0].Nome);
            Assert.Equal(colaboradoresEsperados[1].Nome, result[1].Nome);
        }

        [Fact]
        public async Task CadastrarColaborador_Deve_Retornar_True_Quando_Cadastro_Sucesso()
        {
            // Arrange
            var colaboradorViewModel = new ColaboradorInsertViewModel { Nome = "Novo Colaborador" };

            _mapperMock.Setup(x => x.Map<Colaborador>(It.IsAny<ColaboradorInsertViewModel>())).Returns(new Colaborador());
            _mediatorHandlerMock.Setup(x => x.EnviarComando(It.IsAny<AdicionarColaboradorCommand>())).ReturnsAsync(true);

            // Act
            var result = await _colaboradorAppService.CadastrarColaborador(colaboradorViewModel);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task AtualizarColaborador_Deve_Retornar_True_Quando_Atualizacao_Sucesso()
        {
            // Arrange
            var colaboradorViewModel = new ColaboradorUpdateViewModel { Id = 1, Nome = "Novo Nome" };

            _mapperMock.Setup(x => x.Map<Colaborador>(It.IsAny<ColaboradorUpdateViewModel>())).Returns(new Colaborador());
            _mediatorHandlerMock.Setup(x => x.EnviarComando(It.IsAny<AtualizarColaboradorCommand>())).ReturnsAsync(true);

            // Act
            var result = await _colaboradorAppService.AtualizarColaborador(colaboradorViewModel);

            // Assert
            Assert.True(result);
        }
    }
}
