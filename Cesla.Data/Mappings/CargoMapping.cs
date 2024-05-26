using Cesla.Domain.Entities;
using Core.DomainObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Data.Mappings
{
    public class CargoMapping : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                  .ValueGeneratedOnAdd();

            builder.Property(c => c.DepartamentoId)
                   .HasColumnType("int");

            builder.Property(c => c.Nome)
                   .IsRequired()
                   .HasColumnType("varchar(50)");

            builder.Property(c => c.Salario)
                    .IsRequired();

            builder.HasOne(c => c.Departamento)
                   .WithMany(d => d.Cargos)
                   .HasForeignKey(c => c.DepartamentoId);

            builder.ToTable("cargo_tb");
        }
    }
}
