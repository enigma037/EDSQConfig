using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDSQConfig.Application.ConfigurationDefinitions.Queries
{
    public class ListConfigurationDefinitonResponse
    {
          public int Id { get; set; }
        public string ConfigurationType { get; set; }
        public string ConfigurationDescription { get; set; }
        public string DefaultValue { get; set; }
    }
}
