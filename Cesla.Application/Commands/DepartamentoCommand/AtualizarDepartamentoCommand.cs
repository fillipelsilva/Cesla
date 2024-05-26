using Cesla.Application.Validations.DepartamentoValidation;
using Cesla.Application.Validations.EmpresaValidation;
using Cesla.Domain.Entities;
using Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Application.Commands.DepartamentoCommand
{
    public class AtualizarDepartamentoCommand : Command
    {
        public AtualizarDepartamentoCommand(int id, string nome, int empresaId)
        {
            Nome = nome;
            EmpresaId = empresaId;
            Id = id;
        }

        public string Nome { get; set; }
        public decimal Salario { get; set; }
        public int EmpresaId { get; set; }
        public int Id { get; set; }

        public override bool EhValido()
        {
            ValidationResult = new AtualizarDepartamentoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
