using Cesla.Application.Validations.ColaboradorValidation;
using Cesla.Application.Validations.DepartamentoValidation;
using Cesla.Application.Validations.EmpresaValidation;
using Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Application.Commands.DepartamentoCommand
{
    public class DeletarDepartamentoCommand : Command
    {
        public int Id { get; set; }
        public DeletarDepartamentoCommand(int id)
        {
            Id = id;
        }

        public override bool EhValido()
        {
            ValidationResult = new DeletarDepartamentoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
