using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using University.Data.Entities;

namespace University.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            //Table name
            builder.ToTable("Students");

            //PK
            builder.HasKey(s => s.StudentId);

            builder.Property(s => s.StudentId)
                .UseIdentityColumn(1, 1);

            builder.Property(s => s.StudentName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.StudentEmail)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
