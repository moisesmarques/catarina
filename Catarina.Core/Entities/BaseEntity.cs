using Catarina.Core.IEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catarina.Core.Entities
{
    public abstract class BaseEntity: IAuditableEntity
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ApplicationUser CreatedBy { get; set; }
        public ApplicationUser UpdatedBy { get; set; }

    }
}
