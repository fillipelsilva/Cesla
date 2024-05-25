using Cesla.Application.Validations.ColaboradorValidation;
using Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Application.Commands.ColaboradorCommand
{
    public class AtualizarColaboradorCommand : Command
    {
        public string Nome { get; set; }
        public int CargoId { get; set; }
        public int Id { get; set; }
        public AtualizarColaboradorCommand(int id, string nome, int cargoId)
        {
            Id = id;
            Nome = nome;
            CargoId = cargoId;
        }

        public override bool EhValido()
        {
            ValidationResult = new AtualizarColaboradorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
