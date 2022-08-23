namespace EDSQConfig.Application.ApplicationConfigurations.Queries
{
    public class ListAppConfigsResponse
    {
        public int Id { get; set; }
        public string ApplicationCode { get; set; }
        public int OrganizationId { get; set; }
        public int ConfigurationDefinitionId { get; set; }
        public string ConfigurationValue { get; set; }
        public string OrganizationName { get; set; }
        public string ConfigurationDefinitionName { get; set; }
    }
}
