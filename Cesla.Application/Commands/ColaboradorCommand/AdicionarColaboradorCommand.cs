using Cesla.Application.Validations.ColaboradorValidation;
using Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Application.Commands.ColaboradorCommand
{
    public class AdicionarColaboradorCommand : Command
    {
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public int CargoId { get; set; }
        public AdicionarColaboradorCommand(string nome, int cargoId)
        {
            Nome = nome;
            Ativo = true;
            CargoId = cargoId;
        }

        public override bool EhValido()
        {
            ValidationResult = new AdicionarColaboradorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
