using Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Domain.Entities
{
    public class Endereco : Entity
    {
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string Pais { get; set; }

        public Endereco()
        {

        }

        public Endereco(int id, string rua, int numero, string cidade, string estado, string cep, string pais)
        {
            Id = id;
            Rua = rua;
            Numero = numero;
            Cidade = cidade;
            Estado = estado;
            CEP = cep;
            Pais = pais;
        }
    }
}
