using Igrm.eCommerceProductCatalog.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.eCommerceProductCatalog.Domain
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public int Version { get; set; }

        public bool IsTransient()
        {
            return this.Id == default;
        }
    }
}
