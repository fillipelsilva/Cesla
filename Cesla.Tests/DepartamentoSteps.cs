using Cesla.Data.Repositorios.Interfaces;
using Cesla.Data.Repositorios;
using Cesla.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using FluentAssertions;

namespace Cesla.Tests
{
    [Binding]
    public class AdicionarDepartamentoSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly Departamento _validDepartamento;
        private readonly IDepartamentoRepository _departamentoRepository;

        public AdicionarDepartamentoSteps(ScenarioContext scenarioContext, DepartamentoFixture departamentoFixture, DatabaseFixture dbFixture)
        {
            _scenarioContext = scenarioContext;
            _validDepartamento = departamentoFixture.ValidDepartamento;
            _departamentoRepository = new DepartamentoRepository(dbFixture.Context, dbFixture.Connection);
        }

        [Given(@"que eu tenho um novo departamento válido")]
        public void GivenQueEuTenhoUmNovoDepartamentoValido()
        {
            _scenarioContext["Departamento"] = _validDepartamento;
        }

        [When(@"eu adiciono o departamento")]
        public async void WhenEuAdicionoODepartamento()
        {
            var departamento = (Departamento)_scenarioContext["Departamento"];
            await _departamentoRepository.Adicionar(departamento);
            await _departamentoRepository.Commit();
        }

        [Then(@"o departamento deve ser adicionado ao banco de dados")]
        public async void ThenODepartamentoDeveSerAdicionadoAoBancoDeDados()
        {
            var departamento = (Departamento)_scenarioContext["Departamento"];
            var departamentoInDb = await _departamentoRepository.ObterPorId(departamento.Id);
            departamentoInDb.Should().NotBeNull();
            departamentoInDb.Nome.Should().Be(departamento.Nome);
        }
    }
}
