using Cesla.Application.Validations.EmpresaValidation;
using Cesla.Domain.Entities;
using Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Application.Commands.CargoCommand
{
    public class AtualizarCargoCommand : Command
    {
        public AtualizarCargoCommand(int id, string nome, decimal salario, int departamentoId)
        {
            Nome = nome;
            Salario = salario;
            DepartamentoId = departamentoId;
            Id = id;
        }

        public string Nome { get; set; }
        public decimal Salario { get; set; }
        public int DepartamentoId { get; set; }
        public int Id { get; set; }

        public override bool EhValido()
        {
            ValidationResult = new AtualizarCargoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
