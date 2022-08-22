using EDSQConfig.Application.ApplicationConfigurations.Commands;

namespace EDSQConfig.Application.Test.TestApplicationConfigurations.Commands
{
    public class TestCreateAppConfig : BaseTest
    {
        public TestCreateAppConfig() : base(nameof(TestCreateAppConfig) + _dbCount++)
        {
        }

        [Fact]
        public async Task CreateAppConfigHandler_ShouldCreateApplicationConfiguration()
        {
            // Arrange
            var command = new CreateAppConfigCommand
            {
                OrganizationId = _organizationId,
                ApplicationCode = "ABC",
                ConfigurationDefinitionId = _configurationDefinitionId,
                ConfigurationValue = "Default Test Create"
            };
            var cancellationToken = new CancellationToken();
            var handler = new CreateAppConfigHandler(_dbContext);

            // Act
            var result = await handler.Handle(command, cancellationToken);

            // Assert
            Assert.Contains(_dbContext.ApplicationConfigurations, a => a.OrganizationId == command.OrganizationId &&
                                                                  a.ApplicationCode == command.ApplicationCode &&
                                                                  a.ConfigurationDefinitionId == command.ConfigurationDefinitionId &&
                                                                  a.ConfigurationValue == command.ConfigurationValue);
        }

        [Theory]
        [InlineData(1, "", 1, "Default Test Create", "Code is required.")]
        [InlineData(1, "EDS", 1, "Default Test Create", "")]
        [InlineData(1, "EDSQ", 1, "Default Test Create", "Maximum Character Limit is 3.")]
        public async Task CreateAppConfigValidator_ShouldValidateCreateAppConfigCommand(int organizationId,
                                                                                        string appCode,
                                                                                        int configDefId,
                                                                                        string configValue,
                                                                                        string errorMessage)
        {
            // Arrange
            var command = new CreateAppConfigCommand
            {
                OrganizationId = organizationId,
                ApplicationCode = appCode,
                ConfigurationDefinitionId = configDefId,
                ConfigurationValue = configValue
            };
            var validator = new CreateAppConfigValidator();

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
