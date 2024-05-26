using Cesla.Application.Validations.EmpresaValidation;
using Cesla.Domain.Entities;
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
        public AtualizarEmpresaCommand(int id, string nome, string telefone, Endereco endereco)
        {
            Nome = nome;
            Telefone = telefone;
            Endereco.AtualizarEndereco(endereco.Numero, endereco.Rua, endereco.Cidade, endereco.Estado, endereco.CEP, endereco.Pais);
            Id = id;
        }

        public string Nome { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; } = new Endereco();
        public int Id { get; set; }

        public override bool EhValido()
        {
            ValidationResult = new AtualizarEmpresaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
