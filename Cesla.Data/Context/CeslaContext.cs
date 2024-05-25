using Cesla.Domain.Entities;
using Core.Communication.MediatrHandler;
using Core.Data;
using Core.Messages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Data.Context
{
    public class CeslaContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public CeslaContext(DbContextOptions<CeslaContext> options, IMediatorHandler mediatorHandler)
        : base(options)
        {
            _mediatorHandler = mediatorHandler;
        }

        public DbSet<Colaborador> Colaborador { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Endereco> Endereco { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Endereco>().HasData(new
            {
                Id = 1,
                Rua = "Rua Teste",
                Numero = 20,
                Cidade = "Rio de Janeiro",
                Estado = "RJ",
                CEP = "21345678",
                Pais = "Brasil",
                DataCadastro = DateTime.Now
            });

            modelBuilder.Entity<Empresa>().HasData(new
            {
                Id = 1,
                Nome = "Cesla",
                Telefone = "1101234567",
                EnderecoId = 1,
                DataCadastro = DateTime.Now
            });

            modelBuilder.Entity<Departamento>().HasData(new
            {
                Id = 1,
                Nome = "Administrativo",
                EmpresaId = 1,
                DataCadastro = DateTime.Now
            });

            modelBuilder.Ignore<Event>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CeslaContext).Assembly);

            string baseDirectory = Environment.CurrentDirectory;

            // Combina o diretório base com o nome do arquivo JSON
            string questoesPath = Path.Combine(baseDirectory, "Cargos.json");

            string jsonContent = File.ReadAllText(questoesPath);

            List<Cargo> cargos = JsonConvert.DeserializeObject<List<Cargo>>(jsonContent);

            foreach (var cargo in cargos)
            {
                modelBuilder.Entity<Cargo>()
                .HasData(new
                {
                    cargo.Id,
                    cargo.Nome,
                    cargo.Salario,
                    cargo.DepartamentoId,
                    DataCadastro = DateTime.Now
                });
            }

            foreach (var relationship in modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(e => e
                .GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker
                .Entries()
                .Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            var sucesso = await base.SaveChangesAsync() > 0;
            if (sucesso) await _mediatorHandler.PublicarEventos(this);

            return sucesso;
        }
    }
}
