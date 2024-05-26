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
    public class EmpresaIntegrationTest : IClassFixture<EmpresaFixture>, IClassFixture<DatabaseFixture>
    {
        private readonly Empresa _validEmpresa;
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaIntegrationTest(EmpresaFixture empresaFixture, DatabaseFixture dbFixture)
        {
            _validEmpresa = empresaFixture.ValidEmpresa;
            _empresaRepository = new EmpresaRepository(dbFixture.Context, dbFixture.Connection);
        }

        [Fact]
        public async Task AdicionarEmpresa_ValidEmpresa_ShouldAddEmpresaToDatabase()
        {
            // Arrange
            // Act
            await _empresaRepository.Adicionar(_validEmpresa);
            await _empresaRepository.Commit();

            // Assert
            var empresaInDb = await _empresaRepository.ObterPorId(_validEmpresa.Id);
            empresaInDb.Should().NotBeNull();
            empresaInDb.Nome.Should().Be(_validEmpresa.Nome);
        }
    }

}
