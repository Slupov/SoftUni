using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Models;

namespace TeamBuilder.Data.Configurations
{
    class TeamConfiguration : EntityTypeConfiguration<Team>
    {
        public TeamConfiguration()
        {
            
            this.Property(t => t.Name)
                .HasMaxLength(200)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_Teams_Name", 1) {IsUnique = true}))
                .IsRequired();

            this.Property(t => t.Description)
                .HasMaxLength(32);

            this.Property(t => t.Acronym)
                .HasMaxLength(3)
                .IsRequired();
        }
    }
}