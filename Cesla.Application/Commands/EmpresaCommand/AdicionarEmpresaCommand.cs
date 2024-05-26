using Cesla.Application.Validations.EmpresaValidation;
using Cesla.Application.ViewModels.EnderecoViewModels;
using Cesla.Domain.Entities;
using Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Application.Commands.EmpresaCommand
{
    public class AdicionarEmpresaCommand : Command
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; } = new Endereco();

        public AdicionarEmpresaCommand(string nome, string telefone, Endereco endereco)
        {
            Nome = nome;
            Telefone = telefone;
            Endereco.AdicionarEndereco(endereco.Numero, endereco.Rua, endereco.Cidade, endereco.Estado, endereco.CEP, endereco.Pais);
        }

        public override bool EhValido()
        {
            ValidationResult = new AdicionarEmpresaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
