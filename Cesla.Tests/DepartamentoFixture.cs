using Bogus;
using Cesla.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Tests
{
    public class DepartamentoFixture
    {
        public Departamento ValidDepartamento { get; private set; }

        public DepartamentoFixture()
        {
            var faker = new Faker("pt_BR");
            ValidDepartamento = new Departamento(faker.Random.Int(1, 100), faker.Name.JobArea());
        }
    }
}
