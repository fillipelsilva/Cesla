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
    public class ColaboradorMapping : IEntityTypeConfiguration<Colaborador>
    {
        public void Configure(EntityTypeBuilder<Colaborador> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.CargoId)
                   .HasColumnType("int");

            builder.Property(c => c.Ativo);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.HasOne(c => c.Cargo)
                   .WithMany(ca => ca.Colaboradores)
                   .HasForeignKey(c => c.CargoId);

            builder.ToTable("colaborador_tb");
        }
    }
}
