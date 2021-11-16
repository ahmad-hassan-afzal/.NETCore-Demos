using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> template)
        {
            template.Property(p => p.Id)
                    .HasColumnName("ProjectID");

            template.Property(p => p.Name)
                    .IsRequired()
                    .HasColumnName("ProjectName")
                    .HasMaxLength(30);

            template.Property(p => p.Code)
                    .IsRequired()
                    .HasColumnName("ProjectCode")
                    .HasMaxLength(5);

            template.Property(p => p.Description)
                    .HasColumnName("ProjectDescription")
                    .HasMaxLength(500);

            template.Property(p => p.CompanyId)
                    .IsRequired()
                    .HasColumnName("CompanyID");
        }
    }
}
