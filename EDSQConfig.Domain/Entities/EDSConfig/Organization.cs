using System.Collections.Generic;

namespace EDSQConfig.Domain.Entities.EDSConfig
{
    public class Organization
    {
        public int OrganizationId { get; set; }
        public string Name { get; set; }
        public bool Internal { get; set; }
        public string ClientAlphaID { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<ApplicationConfiguration> ApplicationConfigurations { get; set; }
    }
}
