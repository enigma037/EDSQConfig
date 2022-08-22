using EDSQConfig.Domain.Entities.EDSConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDSQConfig.Infrastructure.Persistence.Configuration
{
    public class AppConfigDbConfig : IEntityTypeConfiguration<ApplicationConfiguration>
    {
        public void Configure(EntityTypeBuilder<ApplicationConfiguration> builder)
        {
            builder.ToTable("ApplicationConfiguration");
            builder.HasKey(h => h.Id);
            builder.Property(p => p.Id)
                   .UseIdentityColumn(1, 1)
                   .ValueGeneratedOnAdd();

            builder.HasOne(h => h.Organization)
                   .WithMany(w => w.ApplicationConfigurations)
                   .HasForeignKey(h => h.OrganizationId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(h => h.ConfigurationDefinition)
                    .WithMany(w =>
                    w.ApplicationConfigurations)
                    .HasForeignKey(h => h.ConfigurationDefinitionId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
