using Cesla.Application.Validations.ColaboradorValidation;
using Cesla.Application.Validations.EmpresaValidation;
using Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Application.Commands.CargoCommand
{
    public class DeletarCargoCommand : Command
    {
        public int Id { get; set; }
        public DeletarCargoCommand(int id)
        {
            Id = id;
        }

        public override bool EhValido()
        {
            ValidationResult = new DeletarCargoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
