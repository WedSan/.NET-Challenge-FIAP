﻿using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityConfiguration
{
    public class MonitoringDataEntityConfig : IEntityTypeConfiguration<MonitoringData>
    {
        public void Configure(EntityTypeBuilder<MonitoringData> builder)
        {
            builder.ToTable("TB_DADO_MONITORAMENTO");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasColumnName("ID");

            builder.Property(e => e.RegistrationDate)
                   .HasColumnName("DATA_REGISTRO");

            builder.HasOne(d => d.User)
                   .WithMany()
                   .HasForeignKey("ID_USUARIO")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(d => d.Problems)
                   .WithOne()
                   .HasForeignKey("ID_RELATO_PROBLEMA USUARIO")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(md => md.DentalAnalyses)
              .WithMany(da => da.MonitoringDataList)
              .UsingEntity<Dictionary<string, object>>(
                  "TB_ANALISE_DENTARIA_DADO_MONITORAMENTO",
                  j => j.HasOne<DentalAnalysis>()
                      .WithMany()
                      .HasForeignKey("ID_ANALISE_DENTARIA")
                      .OnDelete(DeleteBehavior.Restrict),
                  j => j.HasOne<MonitoringData>()
                      .WithMany()
                      .HasForeignKey("ID_DADO_MONITORAMENTO")
                      .OnDelete(DeleteBehavior.Restrict),
          
                  j =>
                  {
                      j.HasKey("ID_ANALISE_DENTARIA", "ID_DADO_MONITORAMENTO");
                  }
              );
        }
    }
}
