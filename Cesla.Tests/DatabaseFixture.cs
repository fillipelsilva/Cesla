using Cesla.Data.Connection;
using Cesla.Data.Context;
using Core.Communication.MediatrHandler;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Tests
{
    public class DatabaseFixture : IDisposable
    {
        public CeslaContext Context { get; private set; }
        public CeslaConnection Connection { get; private set; }

        public DatabaseFixture()
        {
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string> { { "DefaultConnection", "Server=host.docker.internal;Port=3306;Database=cesla;Uid=root;Pwd=#MySQLPassword2024" } })
                .Build();

            Connection = new CeslaConnection(configuration);

            var options = new DbContextOptionsBuilder<CeslaContext>()
                .UseInMemoryDatabase(databaseName: "test_database")
                .Options;

            Connection = new CeslaConnection(configuration);
            Context = new CeslaContext(options, new Mock<IMediatorHandler>().Object);

        }

        public void Dispose()
        {
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }
}
