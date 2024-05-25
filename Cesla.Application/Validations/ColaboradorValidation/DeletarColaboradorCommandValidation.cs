using Cesla.Application.Commands.ColaboradorCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Application.Validations.ColaboradorValidation
{
    public class DeletarColaboradorCommandValidation : AbstractValidator<DeletarColaboaradorCommand>
    {
        public DeletarColaboradorCommandValidation()
        {
            RuleFor(colaborador => colaborador.Id)
                .GreaterThan(0).WithMessage("O Id deve ser maior que 0.");
        }
    }
}
