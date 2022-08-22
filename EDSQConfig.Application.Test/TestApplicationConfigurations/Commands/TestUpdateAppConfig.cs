using EDSQConfig.Application.ApplicationConfigurations.Commands;
using EDSQConfig.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDSQConfig.Application.Test.TestApplicationConfigurations.Commands
{
    public class TestUpdateAppConfig : BaseTest
    {
        public TestUpdateAppConfig() : base(nameof(TestUpdateAppConfig) + _dbCount++)
        {
        }

        [Fact]
        public async Task UpdateAppConfigHandler_ShouldUpdateApplicationConfiguration()
        {
            // Arrange
            var command = new UpdateAppConfigCommand
            {
                Id = 1,
                OrganizationId = _organizationId,
                ApplicationCode = "ABC",
                ConfigurationDefinitionId = _configurationDefinitionId,
                ConfigurationValue = "Default Test Update"
            };
            var cancellationToken = new CancellationToken();
            var handler = new UpdateAppConfigHandler(_dbContext);

            // Act
            var result = await handler.Handle(command, cancellationToken);

            // Assert
            Assert.Contains(_dbContext.ApplicationConfigurations, a => a.OrganizationId == command.OrganizationId &&
                                                                  a.ApplicationCode == command.ApplicationCode &&
                                                                  a.ConfigurationDefinitionId == command.ConfigurationDefinitionId &&
                                                                  a.ConfigurationValue == command.ConfigurationValue);
        }

        [Theory]
        [InlineData(88, "Invalid ApplicationConfiguration id.")]
        public async Task UpdateAppConfigHandler_ShouldThrowExceptionForInvalidAppConfigId(int id, string errorMessage)
        {
            // Arrange
            var command = new UpdateAppConfigCommand
            {
                Id = id
            };
            var cancellationToken = new CancellationToken();
            var handler = new UpdateAppConfigHandler(_dbContext);

            // Act
            var result = await Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(command, cancellationToken));

            // Assert           
            Assert.Equal(result.Message,errorMessage);
        }

        [Theory]
        [InlineData(1, 1, "", 1, "Default Test Update", "Code is required.")]
        [InlineData(1, 1, "EDS", 1, "Default Test Update", "")]
        [InlineData(1, 1, "EDSQ", 1, "Default Test Update", "Maximum Character Limit is 3.")]
        public async Task UpdateAppConfigValidator_ShouldValidateUpdateAppConfigCommand(int id, int organizationId,
                                                                                        string appCode,
                                                                                        int configDefId,
                                                                                        string configValue,
                                                                                        string errorMessage)
        {
            // Arrange
            var command = new UpdateAppConfigCommand
            {
                Id = id,
                OrganizationId = organizationId,
                ApplicationCode = appCode,
                ConfigurationDefinitionId = configDefId,
                ConfigurationValue = configValue
            };
            var validator = new UpdateAppConfigValidator();

            // Act
            var result = await validator.ValidateAsync(command);

            // Assert
            Assert.NotNull(result);
            if (string.IsNullOrEmpty(errorMessage))
            {
                Assert.True(result.IsValid);
                Assert.Empty(result.Errors);
            }
            else
            {
                Assert.False(result.IsValid);
                Assert.Contains(result.Errors, e => e.ErrorMessage.Contains(errorMessage));
            }
        }
    }
}
