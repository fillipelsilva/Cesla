using Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Domain.Entities
{
    public class Cargo : Entity
    {
        public string Nome { get; set; }
        public decimal Salario { get; set; }
        public int DepartamentoId { get; set; }

        //EF Rel.
        public List<Colaborador> Colaboradores { get; set; }
        public Departamento Departamento { get; set; }

        public Cargo()
        {

        }

        public Cargo(int id, string nome, decimal salario)
        {
            Id = id;
            Nome = nome;
            Salario = salario;
        }

        public void AdicionarDepartamento(Departamento departamento)
        {
            Departamento = departamento;
        }

        public void AtualizarCargo(string nome, decimal salario)
        {
            Nome = nome;
            Salario = salario;
        }
    }
}
