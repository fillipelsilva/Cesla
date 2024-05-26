using Cesla.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesla.Data.Mappings
{
    public class DepartamentoMapping : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                  .ValueGeneratedOnAdd();

            builder.Property(d => d.EmpresaId)
                   .HasColumnType("int");

            builder.HasOne(d => d.Empresa)
                   .WithMany(e => e.Departamentos)
                   .HasForeignKey(d => d.EmpresaId);

            builder.ToTable("departamento_tb");
        }
    }
}
