using Cesla.Application.Commands.ColaboradorCommand;
using Cesla.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Application.Validations.ColaboradorValidation
{
    public class AtualizarColaboradorCommandValidation : AbstractValidator<AtualizarColaboradorCommand>
    {
        public AtualizarColaboradorCommandValidation()
        {
            RuleFor(colaborador => colaborador.Nome)
                .NotEmpty().WithMessage("O Nome não pode ser vazio.")
                .Length(2, 100).WithMessage("O Nome deve ter entre 2 e 100 caracteres.");

            RuleFor(colaborador => colaborador.CargoId)
                .GreaterThan(0).WithMessage("O CargoId deve ser maior que 0.");

            RuleFor(colaborador => colaborador.Id)
                .GreaterThan(0).WithMessage("O Id deve ser maior que 0.");
        }
    }
}
