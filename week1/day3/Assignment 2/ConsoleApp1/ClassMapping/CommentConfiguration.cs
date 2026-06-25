using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UniversityDB2.Models;

namespace UniversityDB2.ClassMapping
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            // Table
            builder.ToTable("Comments");

            // PK
            builder.HasKey(c => c.CommentId);
            builder.Property(c => c.CommentId)
                   .UseIdentityColumn(1, 1);

            // Properties
            builder.Property(x => x.CommentContent)
                   .IsRequired(false)
                   .HasMaxLength(100);

            builder.Property(x => x.CreatedDate)
                   .IsRequired();

            // Relationships
            builder.HasOne(c => c.User)
                    .WithMany(u => u.Comments)
                    .HasForeignKey(c => c.UserId);

            builder.HasOne(c => c.Assignment)
                    .WithMany(a => a.Comments)
                    .HasForeignKey(c => c.AssignmentId);

        }
    }
}
