using AutoMapper;
using Bogus;
using Cesla.Application.AppServices;
using Cesla.Application.Commands.CargoCommand;
using Cesla.Application.Queries.CargoQueries;
using Cesla.Application.Queries.Interfaces;
using Cesla.Application.ViewModels.CargoViewModels;
using Core.Communication.MediatrHandler;
using Moq;

namespace Cesla.Tests
{
    public class CargoUnitTests
    {
        private Mock<ICargoQueries> _cargoQueriesMock;
        private Mock<IMediatorHandler> _mediatorHandlerMock;
        private Mock<IMapper> _mapperMock;

        public CargoUnitTests()
        {
            _cargoQueriesMock = new Mock<ICargoQueries>();
            _mediatorHandlerMock = new Mock<IMediatorHandler>();
            _mapperMock = new Mock<IMapper>();
        }

        [Fact]
        public async Task CadastrarCargo_DeveRetornarFalse_QuandoViewModelForNula()
        {
            // Arrange
            var cargoAppService = new CargoAppService(_cargoQueriesMock.Object, _mediatorHandlerMock.Object, _mapperMock.Object);

            // Act
            var resultado = await cargoAppService.CadastrarCargo(null);

            // Assert
            Assert.False(resultado);
        }

        [Fact]
        public async Task ListarCargos_DeveRetornarListaDeCargos_QuandoExistiremCargos()
        {
            // Arrange
            var cargos = new List<CargoQueryResultViewModel>
            {
                new CargoQueryResultViewModel { Id = 1, Nome = "Cargo 1", Salario = 1000 },
                new CargoQueryResultViewModel { Id = 2, Nome = "Cargo 2", Salario = 1500 }
            };
            _cargoQueriesMock.Setup(cq => cq.ListarCargos()).ReturnsAsync(cargos);
            var cargoAppService = new CargoAppService(_cargoQueriesMock.Object, _mediatorHandlerMock.Object, _mapperMock.Object);

            // Act
            var resultado = await cargoAppService.ListarCargos();

            // Assert
            Assert.Equal(2, resultado.Count);
        }

        [Fact]
        public async Task AtualizarCargo_DeveRetornarFalse_QuandoViewModelForNula()
        {
            // Arrange
            var cargoAppService = new CargoAppService(_cargoQueriesMock.Object, _mediatorHandlerMock.Object, _mapperMock.Object);

            // Act
            var resultado = await cargoAppService.AtualizarCargo(null);

            // Assert
            Assert.False(resultado);
        }

        [Fact]
        public async Task DeletarCargo_DeveRetornarFalse_QuandoIdForZeroOuNegativo()
        {
            // Arrange
            var cargoAppService = new CargoAppService(_cargoQueriesMock.Object, _mediatorHandlerMock.Object, _mapperMock.Object);

            // Act
            var resultado = await cargoAppService.DeletarCargo(0);

            // Assert
            Assert.False(resultado);

            // Arrange
            resultado = await cargoAppService.DeletarCargo(-1);

            // Assert
            Assert.False(resultado);
        }


    }
}
