using Bogus;
using Cesla.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Tests
{
    public class EmpresaFixture
    {
        public Empresa ValidEmpresa { get; private set; }

        public EmpresaFixture()
        {
            var faker = new Faker("pt_BR");
            ValidEmpresa = new Empresa(faker.Random.Int(1, 100), faker.Company.CompanyName(), faker.Phone.PhoneNumber());
        }
    }
}
