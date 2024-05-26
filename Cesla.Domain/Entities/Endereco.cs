using Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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

        public override string ToString()
        {
            return $"Rua: {Rua}, Nº: {Numero}, Cidade: {Cidade}, Estado: {Estado}, CEP: {CEP}, País: {Pais}";
        }

        public void AdicionarEndereco(int numero, string rua, string cidade, string estado, string cep, string pais)
        {
            Rua = rua;
            Numero = numero;
            Cidade = cidade;
            Estado = estado;
            CEP = cep;
            Pais = pais;
        }

        public void AtualizarEndereco(int numero, string rua, string cidade, string estado, string cep, string pais)
        {
            Rua = rua;
            Numero = numero;
            Cidade = cidade;
            Estado = estado;
            CEP = cep;
            Pais = pais;
        }
    }
}
