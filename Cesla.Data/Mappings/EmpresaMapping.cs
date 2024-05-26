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
    public class EmpresaMapping : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                  .ValueGeneratedOnAdd();

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(e => e.Telefone)
                .IsRequired()
                .HasColumnType("varchar(11)");

            builder.HasOne(e => e.Endereco)
                .WithOne()
                .HasForeignKey<Empresa>(e => e.EnderecoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("empresa_tb");
        }
    }
}
