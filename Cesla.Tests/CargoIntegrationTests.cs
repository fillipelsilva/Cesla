using AutoMapper;
using Cesla.Application.AppServices;
using Cesla.Application.AutoMapper;
using Cesla.Application.Queries.CargoQueries;
using Cesla.Application.ViewModels.CargoViewModels;
using Cesla.Data.Context;
using Cesla.Data.Repositorios;
using Cesla.Data.Repositorios.Interfaces;
using Core.Communication.MediatrHandler;
using FluentAssertions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Tests
{
    public class CargoIntegrationTest : IClassFixture<CargoFixture>, IClassFixture<DatabaseFixture>
    {
        private readonly Domain.Entities.Cargo _validCargo;
        private readonly ICargoRepository _cargoRepository;
        private readonly Mock<IMediatorHandler> _mediatorHandlerMock;

        public CargoIntegrationTest(CargoFixture cargoFixture, DatabaseFixture dbFixture)
        {
            _validCargo = cargoFixture.ValidCargo;
            _mediatorHandlerMock = new Mock<IMediatorHandler>();
            _cargoRepository = new CargoRepository(dbFixture.Context, dbFixture.Connection);
        }

        [Fact]
        public async Task AdicionarCargo_ValidCargo_ShouldAddCargoToDatabase()
        {
            // Arrange
            // Act
            await _cargoRepository.Adicionar(_validCargo);
            await _cargoRepository.Commit();

            // Assert
            var cargoInDb = await _cargoRepository.ObterPorId(_validCargo.Id);
            cargoInDb.Should().NotBeNull();
            cargoInDb.Nome.Should().Be(_validCargo.Nome);
        }
    }

}
