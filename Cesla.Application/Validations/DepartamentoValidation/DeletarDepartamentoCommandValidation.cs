using Cesla.Application.Commands.CargoCommand;
using Cesla.Application.Commands.DepartamentoCommand;
using Cesla.Application.Commands.EmpresaCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Application.Validations.DepartamentoValidation
{
    public class DeletarDepartamentoCommandValidation : AbstractValidator<DeletarDepartamentoCommand>
    {
        public DeletarDepartamentoCommandValidation()
        {
            RuleFor(departamento => departamento.Id)
                .GreaterThan(0).WithMessage("O Id deve ser maior que 0.");
        }
    }
}
