using Cesla.Application.Commands.EmpresaCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Application.Validations.EmpresaValidation
{
    public class DeletarEmpresaCommandValidation : AbstractValidator<DeletarEmpresaCommand>
    {
        public DeletarEmpresaCommandValidation()
        {
            RuleFor(empresa => empresa.Id)
                .GreaterThan(0).WithMessage("O Id deve ser maior que 0.");
        }
    }
}
