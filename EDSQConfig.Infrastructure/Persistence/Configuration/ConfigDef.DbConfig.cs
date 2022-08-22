using EDSQConfig.Domain.Entities.EDSConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDSQConfig.Infrastructure.Persistence.Configuration
{
    public class ConfigDefDbConfig : IEntityTypeConfiguration<ConfigurationDefinition>
    {
        public void Configure(EntityTypeBuilder<ConfigurationDefinition> builder)
        {
            builder.ToTable("ConfigurationDefinition");
            builder.HasKey(h => h.Id);
            builder.Property(p => p.Id)
                   .UseIdentityColumn(1, 1)
                   .ValueGeneratedOnAdd();

        }
    }
}
