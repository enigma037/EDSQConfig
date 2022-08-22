
using EDSQConfig.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDSQConfig.Application.Test
{
    public abstract class BaseTest
    {
        protected int _organizationId = 1, _configurationDefinitionId = 1, _applicationConfigId = 1;
        protected DbContextOptionsBuilder<EDSConfigDbContext> _dbContextBuilder;
        protected EDSConfigDbContext _dbContext;
        protected static int _dbCount = 1;
        protected BaseTest(string uniqueDbName)
        {
            _dbContextBuilder = new DbContextOptionsBuilder<EDSConfigDbContext>().UseInMemoryDatabase(uniqueDbName);
            _dbContext = new EDSConfigDbContext(_dbContextBuilder.Options);
            SeedDatabase();
        }

        private void SeedDatabase()
        {
            using var dbContext = new EDSConfigDbContext(_dbContextBuilder.Options);
            dbContext.Database.EnsureCreated();
            dbContext.Database.EnsureDeleted();

            // Insert Organization
            dbContext.Organizations.Add(new Organization
            {
                OrganizationId = _organizationId,
                Name = "Aetna",
                ClientAlphaID = "AET",
                Active = true,
            });

            // Insert Configuration Definition
            dbContext.ConfigurationDefinitions.Add(new ConfigurationDefinition
            {
                Id = _configurationDefinitionId,
                ConfigurationType = "Type1",
                ConfigurationDescription = "Type 1"
            });

            // Insert Application Configuration
            dbContext.ApplicationConfigurations.Add(new ApplicationConfiguration
            {
                Id = _applicationConfigId,
                ApplicationCode = "EDS",
                ConfigurationDefinitionId = 1,
                ConfigurationValue = "ABC",
                OrganizationId = _organizationId,
            });

           dbContext.SaveChanges();
        }
    }
}
