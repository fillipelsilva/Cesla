using Cesla.Application.Validations.ColaboradorValidation;
using Cesla.Application.Validations.EmpresaValidation;
using Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Application.Commands.EmpresaCommand
{
    public class DeletarEmpresaCommand : Command
    {
        public int Id { get; set; }
        public DeletarEmpresaCommand(int id)
        {
            Id = id;
        }

        public override bool EhValido()
        {
            ValidationResult = new DeletarEmpresaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
