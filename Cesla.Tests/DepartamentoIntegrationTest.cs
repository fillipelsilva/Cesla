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
    public class DepartamentoIntegrationTest : IClassFixture<DepartamentoFixture>, IClassFixture<DatabaseFixture>
    {
        private readonly Departamento _validDepartamento;
        private readonly IDepartamentoRepository _departamentoRepository;

        public DepartamentoIntegrationTest(DepartamentoFixture departamentoFixture, DatabaseFixture dbFixture)
        {
            _validDepartamento = departamentoFixture.ValidDepartamento;
            _departamentoRepository = new DepartamentoRepository(dbFixture.Context, dbFixture.Connection);
        }

        [Fact]
        public async Task AdicionarDepartamento_ValidDepartamento_ShouldAddDepartamentoToDatabase()
        {
            // Arrange
            // Act
            await _departamentoRepository.Adicionar(_validDepartamento);
            await _departamentoRepository.Commit();

            // Assert
            var departamentoInDb = await _departamentoRepository.ObterPorId(_validDepartamento.Id);
            departamentoInDb.Should().NotBeNull();
            departamentoInDb.Nome.Should().Be(_validDepartamento.Nome);
        }
    }
}
