using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> template)
        {
            template.Property(c => c.Id)
                   .HasColumnName("CompanyID");

            template.Property(c => c.Name)
                    .IsRequired()
                    .HasColumnName("CompanyName")
                    .HasMaxLength(30);

            template.Property(c => c.Name)
                    .IsRequired()
                    .HasColumnName("CompanyWebsite")
                    .HasMaxLength(100);

            template.Property(c => c.Name)
                    .IsRequired()
                    .HasColumnName("CompanyPhone")
                    .HasMaxLength(20);

            template.Property(c => c.Name)
                    .IsRequired()
                    .HasColumnName("CompanyPhone")
                    .HasMaxLength(20);
        }
    }
}
