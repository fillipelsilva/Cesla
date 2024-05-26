using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Tests
{
    public class CargoFixture
    {
        public Domain.Entities.Cargo ValidCargo { get; private set; }

        public CargoFixture()
        {
            var faker = new Faker("pt_BR");
            ValidCargo = new Domain.Entities.Cargo(faker.Random.Int(1, 100), faker.Name.JobTitle(), faker.Random.Decimal(1000, 10000));
        }
    }
}
