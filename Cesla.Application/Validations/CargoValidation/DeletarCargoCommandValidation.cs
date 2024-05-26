using Cesla.Application.Commands.CargoCommand;
using Cesla.Application.Commands.EmpresaCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Application.Validations.EmpresaValidation
{
    public class DeletarCargoCommandValidation : AbstractValidator<DeletarCargoCommand>
    {
        public DeletarCargoCommandValidation()
        {
            RuleFor(cargo => cargo.Id)
                .GreaterThan(0).WithMessage("O Id deve ser maior que 0.");
        }
    }
}
