using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDSQConfig.Domain.Entities.HRPConfig
{
    public class SSIS_Config : AuditableEntity
    {
        public string ConfigurationFilter { get; set; }
        public string ConfigurationName { get; set; }
        public string PackagePath { get; set; }
        public string ConfiguredValueType { get; set; }
    }
}
