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
    public class AtualizarEmpresaCommandValidation : AbstractValidator<AtualizarEmpresaCommand>
    {
        public AtualizarEmpresaCommandValidation()
        {
            RuleFor(empresa => empresa.Nome)
                .NotEmpty().WithMessage("O Nome não pode ser vazio.")
                .Length(2, 100).WithMessage("O Nome deve ter entre 2 e 100 caracteres.");

            RuleFor(empresa => empresa.Telefone)
                .Length(10, 11).WithMessage("O Nome deve ter entre 10 e 11 caracteres.");

            RuleFor(empresa => empresa.Id)
                .GreaterThan(0).WithMessage("O Id deve ser maior que 0.");
        }
    }

}
