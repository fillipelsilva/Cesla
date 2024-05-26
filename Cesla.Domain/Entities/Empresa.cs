using Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Domain.Entities
{
    public class Empresa : Entity
    {

        public string Nome { get; set; }
        public string Telefone { get; set; }
        public int EnderecoId { get; set; }

        //EF Rel.
        public Endereco Endereco { get; set; }
        public List<Departamento> Departamentos { get; set; }

        public Empresa(int id, string nome, string telefone)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
        }

        public Empresa() { }

        public void AdicionarEndereco(Endereco endereco)
        {
            Endereco = endereco;
        }

        public void AtualizarEmpresa(string nome, string telefone)
        {
            Nome = nome;
            Telefone = telefone;
        }
    }
}
