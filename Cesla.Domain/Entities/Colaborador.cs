using Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Domain.Entities
{
    public class Colaborador : Entity
    {
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public int CargoId { get; set; }

        //EF Rel.
        public Cargo Cargo { get; set; }

        public Colaborador()
        {
                
        }
        public Colaborador(int id, string nome, int cargoId, bool ativo)
        {
            Id = id;
            Nome = nome;
            CargoId = cargoId;
            Ativo = ativo;
        }

        public void AdicionarCargo(Cargo cargo)
        {
            Cargo = cargo;
        }

        public void AtualizarColaborador(string nome)
        {
            Nome = nome;
        }

        public void DeletarColaborador()
        {
            Ativo = false;
        }
    }
}
