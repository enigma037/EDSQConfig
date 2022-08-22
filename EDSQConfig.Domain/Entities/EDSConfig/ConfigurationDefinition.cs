using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDSQConfig.Domain.Entities.EDSConfig
{
    public class ConfigurationDefinition 
    {

        public int Id { get; set; }
        public string ConfigurationType { get; set; }
        public string ConfigurationDescription { get; set; }
        public string DefaultValue { get; set; }
        public int CreateUserId { get; set; } = 0;
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
        public int LastUpdateUserId { get; set; } = 0;
        public DateTime LastUpdateDateTime { get; set; } = DateTime.Now;

        public virtual ICollection<ApplicationConfiguration> ApplicationConfigurations { get; set; }
    }
}
