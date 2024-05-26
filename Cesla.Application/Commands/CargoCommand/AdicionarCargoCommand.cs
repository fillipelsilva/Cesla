using Cesla.Application.Validations.EmpresaValidation;
using Cesla.Application.ViewModels.EnderecoViewModels;
using Cesla.Domain.Entities;
using Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Application.Commands.CargoCommand
{
    public class AdicionarCargoCommand : Command
    {
        public AdicionarCargoCommand(string nome, decimal salario, int departamentoId)
        {
            Nome = nome;
            Salario = salario;
            DepartamentoId = departamentoId;
        }

        public string Nome { get; set; }
        public decimal Salario { get; set; }
        public int DepartamentoId { get; set; }

        public override bool EhValido()
        {
            ValidationResult = new AdicionarCargoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
