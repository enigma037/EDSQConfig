using EDSQConfig.Domain.Entities.EDSConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDSQConfig.Infrastructure.Persistence.Configuration
{
    public class OrganizationDbConfig: IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.ToTable("Organization");
            builder.HasKey(h => h.OrganizationId);
            builder.Property(p => p.OrganizationId);

        }
    }
}
