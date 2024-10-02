using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityConfiguration
{
    public class DentalProcedureEntityConfig : IEntityTypeConfiguration<DentalProcedure>
    {
        public void Configure(EntityTypeBuilder<DentalProcedure> builder)
        {
            builder.ToTable("TB_PROCEDIMENTO_DENTARIO");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasColumnName("ID");

            builder.Property(e => e.Name)
                   .HasColumnName("PROCEDIMENTO");
        }
    }
}
