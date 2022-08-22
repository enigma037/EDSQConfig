using EDSQConfig.Domain.Enums;
using System;

namespace EDSQConfig.Domain.Entities
{
    public abstract class AuditableEntity
    {
        public DataStatus DataStatus { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset LastUpdatedAt { get; set; } = DateTimeOffset.UtcNow;
        public string LastUpdatedBy { get; set; } = "TODO";
    }
}
