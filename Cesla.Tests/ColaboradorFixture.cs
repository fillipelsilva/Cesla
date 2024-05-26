using Bogus;
using Cesla.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Tests
{
    public class ColaboradorFixture
    {
        public Colaborador ValidColaborador { get; private set; }

        public ColaboradorFixture()
        {
            var faker = new Faker("pt_BR");
            ValidColaborador = new Colaborador(faker.Random.Int(1, 100), faker.Name.FullName(), faker.Random.Int(1000, 10000), true);
        }
    }
}
