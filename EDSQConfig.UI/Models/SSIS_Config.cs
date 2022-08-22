using System.ComponentModel.DataAnnotations.Schema;

namespace EDSQConfig.UI.Models
{
    public class SSIS_Config
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string ConfigurationFilter { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string ConfiguredValue { get; set; }
        
        [Column(TypeName = "nvarchar(255)")]
        public string PackagePath { get; set; }
        
        [Column(TypeName = "nvarchar(20)")]
        public string ConfiguredValueType { get; set; }
    }
}
