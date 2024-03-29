﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestCatalog.Host.Data.Entities;

namespace TestCatalog.Host.Data.EntityConfigurations;

public class QuestionEntityConfiguration
    : IEntityTypeConfiguration<QuestionEntity>
{
    public void Configure(EntityTypeBuilder<QuestionEntity> builder)
    {
        builder.ToTable("Question");

        builder.HasKey(ci => ci.Id);

        builder.Property(ci => ci.Id)
            .UseHiLo("question_hilo")
            .IsRequired();

        builder.Property(cb => cb.TestId)
            .IsRequired();

        builder.Property(cg => cg.Question)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasOne(ci => ci.Test)
            .WithMany()
            .HasForeignKey(ci => ci.TestId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}