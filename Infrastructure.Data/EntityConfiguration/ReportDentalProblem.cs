﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Infrastructure.EntityConfiguration
{
    public class ProblemReportEntityConfig : IEntityTypeConfiguration<ReportDentalProblem>
    {
        public void Configure(EntityTypeBuilder<ReportDentalProblem> builder)
        {
            builder.ToTable("TB_RELATO_PROBLEMA_DENTARIO");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasColumnName("ID");

            builder.Property(e => e.Problem)
                   .HasColumnName("PROBLEMA");
        }
    }
}
