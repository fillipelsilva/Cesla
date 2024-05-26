using Cesla.Application.Validations.DepartamentoValidation;
using Cesla.Application.Validations.EmpresaValidation;
using Cesla.Application.ViewModels.EnderecoViewModels;
using Cesla.Domain.Entities;
using Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Application.Commands.DepartamentoCommand
{
    public class AdicionarDepartamentoCommand : Command
    {
        public AdicionarDepartamentoCommand(string nome, int empresaId)
        {
            Nome = nome;
            EmpresaId = empresaId;
        }

        public string Nome { get; set; }
        public int EmpresaId { get; set; }

        public override bool EhValido()
        {
            ValidationResult = new AdicionarDepartamentoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
