using Cesla.Application.Validations.EmpresaValidation;
using Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Application.Commands.EmpresaCommand
{
    public class AtualizarEmpresaCommand : Command
    {
        public AtualizarEmpresaCommand(int id, string nome, string telefone, int enderecoId)
        {
            Nome = nome;
            Telefone = telefone;
            EnderecoId = enderecoId;
            Id = id;
        }

        public string Nome { get; set; }
        public string Telefone { get; set; }
        public int EnderecoId { get; set; }
        public int Id { get; set; }

        public override bool EhValido()
        {
            ValidationResult = new AtualizarEmpresaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
