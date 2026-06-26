using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UniversityDB2.Models;

namespace UniversityDB2.ClassMapping
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Table
            builder.ToTable("Users");

            // PK
            builder.HasKey(x => x.UserId);

            // Properties
            builder.Property(x => x.UserId)
                   .UseIdentityColumn(1, 1);

            builder.Property(x => x.UserName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.FirstName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.LastName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.EmailAddress)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.HasIndex(x => x.EmailAddress)
                   .IsUnique();

            builder.Property(x => x.PhoneNumber)
                   .IsRequired()
                   .HasMaxLength(16);

            builder.Property(x => x.Role)
                   .IsRequired()
                   .HasMaxLength(32);

            // Relationships
            //written in commentConfig
            //builder.HasMany(u => u.Comments)
            //    .WithOne(c => c.User)
            //    .HasForeignKey(c => c.UserId);

            //written in courseConfig
            //builder.HasMany(u=>u.Courses)
            //    .WithOne(co=>co.Teacher)
            //    .HasForeignKey(co => co.TeacherId);

            //written in gradeConfig
            //builder.HasMany(u => u.Grades)
            //    .WithOne(g => g.Student)
            //    .HasForeignKey(g => g.StudentId);
        }
    }
}
