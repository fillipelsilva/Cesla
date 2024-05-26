using Cesla.Application.AppServices;
using Cesla.Application.ViewModels.CargoViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Cesla.Tests
{
    [Binding]
    public class CargoSteps
    {
        private readonly CargoAppService _cargoAppService;
        private CargoInsertViewModel _cargoViewModel;
        private bool _result;

        public CargoSteps(CargoAppService cargoAppService)
        {
            _cargoAppService = cargoAppService;
        }

        [Given(@"que eu tenho um cargo válido")]
        public void DadoQueEuTenhoUmCargoValido()
        {
            _cargoViewModel = new CargoInsertViewModel
            {
                Nome = "Developer",
                Salario = 3000,
                DepartamentoId = 1
            };
        }

        [When(@"eu cadastrar o cargo")]
        public async Task QuandoEuCadastrarOCargo()
        {
            _result = await _cargoAppService.CadastrarCargo(_cargoViewModel);
        }

        [Then(@"o cargo deve ser salvo no sistema")]
        public void EntaoOCargoDeveSerSalvoNoSistema()
        {
            Assert.True(_result);
        }
    }
}
