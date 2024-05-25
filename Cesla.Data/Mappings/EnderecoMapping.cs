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
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Rua)
                .HasColumnName("Rua")
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(e => e.Cidade)
                .HasColumnName("Cidade")
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(e => e.Estado)
                .HasColumnName("Estado")
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(e => e.CEP)
                .HasColumnName("CEP")
                .IsRequired()
                .HasColumnType("varchar(8)");

            builder.Property(e => e.Pais)
                .HasColumnName("Pais")
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(e => e.Numero)
                .HasColumnName("Numero")
                .IsRequired();

            builder.ToTable("endereco_tb");
        }
    }
}
