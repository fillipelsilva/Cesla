using Cesla.Data.Repositorios.Interfaces;
using Cesla.Data.Repositorios;
using Cesla.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace Cesla.Tests
{
    public class ColaboradorIntegrationTest : IClassFixture<ColaboradorFixture>, IClassFixture<DatabaseFixture>
    {
        private readonly Colaborador _validColaborador;
        private readonly IColaboradoresRepository _colaboradorRepository;

        public ColaboradorIntegrationTest(ColaboradorFixture colaboradorFixture, DatabaseFixture dbFixture)
        {
            _validColaborador = colaboradorFixture.ValidColaborador;
            _colaboradorRepository = new ColaboradoresRepository(dbFixture.Context, dbFixture.Connection);
        }

        [Fact]
        public async Task AdicionarColaborador_ValidColaborador_ShouldAddColaboradorToDatabase()
        {
            // Arrange
            // Act
            await _colaboradorRepository.Adicionar(_validColaborador);
            await _colaboradorRepository.Commit();

            // Assert
            var colaboradorInDb = await _colaboradorRepository.ObterPorId(_validColaborador.Id);
            colaboradorInDb.Should().NotBeNull();
            colaboradorInDb.Nome.Should().Be(_validColaborador.Nome);
        }
    }

}
