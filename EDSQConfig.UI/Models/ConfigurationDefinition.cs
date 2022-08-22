using System.ComponentModel.DataAnnotations;

namespace EDSQConfig.UI.Models
{
    public class ConfigurationDefinition
    {
        public int ID { get; set; }
        [StringLength(50)]
        public string ConfigurationType { get; set; }
        [StringLength(500)]
        public string? ConfigurationDescription { get; set; }
        [StringLength(256)]
        public string? DefaultValue { get; set; }
        public int CreateUserID { get; set; }
        public DateTime CreateDateTime { get; set; }
        public int LastUpdateUserID { get; set; }
        public DateTime LastUpdateDateTime { get; set; }
    }
}
