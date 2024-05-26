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
    public class AdicionarColaboradorSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly Colaborador _validColaborador;
        private readonly IColaboradoresRepository _colaboradorRepository;

        public AdicionarColaboradorSteps(ScenarioContext scenarioContext, ColaboradorFixture colaboradorFixture, DatabaseFixture dbFixture)
        {
            _scenarioContext = scenarioContext;
            _validColaborador = colaboradorFixture.ValidColaborador;
            _colaboradorRepository = new ColaboradoresRepository(dbFixture.Context, dbFixture.Connection);
        }

        [Given(@"que eu tenho um novo colaborador válido")]
        public void GivenQueEuTenhoUmNovoColaboradorValido()
        {
            _scenarioContext["Colaborador"] = _validColaborador;
        }

        [When(@"eu adiciono o colaborador")]
        public async void WhenEuAdicionoOColaborador()
        {
            var colaborador = (Colaborador)_scenarioContext["Colaborador"];
            await _colaboradorRepository.Adicionar(colaborador);
            await _colaboradorRepository.Commit();
        }

        [Then(@"o colaborador deve ser adicionado ao banco de dados")]
        public async void ThenOColaboradorDeveSerAdicionadoAoBancoDeDados()
        {
            var colaborador = (Colaborador)_scenarioContext["Colaborador"];
            var colaboradorInDb = await _colaboradorRepository.ObterPorId(colaborador.Id);
            colaboradorInDb.Should().NotBeNull();
            colaboradorInDb.Nome.Should().Be(colaborador.Nome);
        }
    }

}
