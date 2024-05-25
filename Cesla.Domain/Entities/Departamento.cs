using Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Domain.Entities
{
    public class Departamento : Entity
    {
        public string Nome { get; set; }
        public int EmpresaId { get; set; }

        // EF Rel.
        public Empresa Empresa { get; set; }
        public List<Cargo> Cargos { get; set; } = new List<Cargo>();

        public Departamento()
        {
                
        }
        public Departamento(int id, string nome, int empresaId)
        {
            Id = id;
            Nome = nome;
            EmpresaId = empresaId;
        }
    }
}
