using System.ComponentModel.DataAnnotations;

namespace EDSQConfig.UI.Models
{
    public class ApplicationConfiguration
    {
        
        public int ID { get; set; }
        [StringLength(12)]
        public string ApplicationCode { get; set; }
        public int OrganizationId { get; set; }
        public int ConfigurationDefinitionId { get; set; }
        [StringLength(256)]
        public string ConfigurationValue { get; set; }
        public string OrganizationName { get; set; }
        public string ConfigurationDefinitionName { get; set; }
    }
}
