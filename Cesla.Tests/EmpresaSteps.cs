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
    public class AdicionarEmpresaSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly Empresa _validEmpresa;
        private readonly IEmpresaRepository _empresaRepository;

        public AdicionarEmpresaSteps(ScenarioContext scenarioContext, EmpresaFixture empresaFixture, DatabaseFixture dbFixture)
        {
            _scenarioContext = scenarioContext;
            _validEmpresa = empresaFixture.ValidEmpresa;
            _empresaRepository = new EmpresaRepository(dbFixture.Context, dbFixture.Connection);
        }

        [Given(@"que eu tenho uma nova empresa válida")]
        public void GivenQueEuTenhoUmaNovaEmpresaValida()
        {
            _scenarioContext["Empresa"] = _validEmpresa;
        }

        [When(@"eu adiciono a empresa")]
        public async void WhenEuAdicionoAEmpresa()
        {
            var empresa = (Empresa)_scenarioContext["Empresa"];
            await _empresaRepository.Adicionar(empresa);
            await _empresaRepository.Commit();
        }

        [Then(@"a empresa deve ser adicionada ao banco de dados")]
        public async void ThenAEmpresaDeveSerAdicionadaAoBancoDeDados()
        {
            var empresa = (Empresa)_scenarioContext["Empresa"];
            var empresaInDb = await _empresaRepository.ObterPorId(empresa.Id);
            empresaInDb.Should().NotBeNull();
            empresaInDb.Nome.Should().Be(empresa.Nome);
        }
    }

}
