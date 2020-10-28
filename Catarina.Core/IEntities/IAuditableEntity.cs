using Catarina.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catarina.Core.IEntities
{
    public interface IAuditableEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ApplicationUser CreatedBy { get; set; }
        public ApplicationUser UpdatedBy { get; set; }
    }
}
