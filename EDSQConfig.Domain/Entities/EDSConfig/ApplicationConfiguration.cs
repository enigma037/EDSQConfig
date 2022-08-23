using System;

namespace EDSQConfig.Domain.Entities.EDSConfig
{
    public class ApplicationConfiguration 
    {
        public int ID { get; set; }
        public string ApplicationCode { get; set; }
        public int OrganizationId { get; set; }
        public int ConfigurationDefinitionId { get; set; }
        public string ConfigurationValue { get; set; }
        public DateTime? DisabledDateTime { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual ConfigurationDefinition ConfigurationDefinition { get; set; }
    }
}
