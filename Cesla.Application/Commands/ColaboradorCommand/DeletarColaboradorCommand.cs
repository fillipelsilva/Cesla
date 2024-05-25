using Cesla.Application.Validations.ColaboradorValidation;
using Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Application.Commands.ColaboradorCommand
{
    public class DeletarColaboaradorCommand : Command
    {
        public int Id { get; set; }
        public DeletarColaboaradorCommand(int id)
        {
            Id = id;
        }

        public override bool EhValido()
        {
            ValidationResult = new DeletarColaboradorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
