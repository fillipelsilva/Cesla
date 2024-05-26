using Cesla.Application.Commands.CargoCommand;
using Cesla.Application.Commands.EmpresaCommand;
using Cesla.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Application.Validations.EmpresaValidation
{
    public class AtualizarCargoCommandValidation : AbstractValidator<AtualizarCargoCommand>
    {
        public AtualizarCargoCommandValidation()
        {
            RuleFor(cargo => cargo.Nome)
                .NotEmpty().WithMessage("O Nome não pode ser vazio.")
                .Length(2, 100).WithMessage("O Nome deve ter entre 2 e 100 caracteres.");

            RuleFor(cargo => cargo.Salario)
                .GreaterThan(0).WithMessage("O Salário deve ser maior que 0.");

            RuleFor(cargo => cargo.DepartamentoId)
                .GreaterThan(0).WithMessage("O Id deve ser maior que 0.");
        }
    }

}
