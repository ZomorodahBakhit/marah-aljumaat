using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UniversityDB2.Models;

namespace UniversityDB2.ClassMapping
{
    public class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            // Table
            builder.ToTable("Grades");

            // PK
            builder.HasKey(g => g.GradeId);
            builder.Property(g => g.GradeId)
                   .UseIdentityColumn(1, 1);

            // Properties
            builder.Property(x => x.GradeNumber)
                   .IsRequired();
                  
            // Relationships
            builder.HasOne(g => g.Student)
                    .WithMany(s => s.Grades)
                    .HasForeignKey(g => g.StudentId);

            builder.HasOne(g => g.Assignment)
                    .WithMany(a => a.Grades)
                    .HasForeignKey(g => g.AssignmentId);

        }
    }
}
