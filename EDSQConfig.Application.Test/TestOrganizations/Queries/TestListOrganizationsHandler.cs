using EDSQConfig.Application.Organizations.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDSQConfig.Application.Test.TestOrganizations.Queries
{
    public class TestListOrganizationsHandler : BaseTest
    {
        public TestListOrganizationsHandler() : base(nameof(TestListOrganizationsHandler) + _dbCount++)
        {
        }

        [Fact]
        public async Task ListOrganizationsHandler_ShouldReturnOrganizationList()
        {
            // Arrange
            var query = new ListOrganizationsQuery { };
            var handler = new ListOrganizationsHandler(_dbContext);
            var cancellationToken = new CancellationToken();

            // Act
            var result = await handler.Handle(query, cancellationToken);

            // Assert
            Assert.NotNull(result);
            Assert.Contains(result, a => a.OrganizationId == _organizationId);

        }
    }
}
