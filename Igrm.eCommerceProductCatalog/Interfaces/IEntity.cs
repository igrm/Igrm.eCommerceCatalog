using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.eCommerceProductCatalog.Interfaces
{
    public interface IEntity
    {
        Guid Id { get; set; }
        bool IsTransient();
        DateTime Created { get; set; }
        DateTime Modified { get; set; }
        int Version { get; set; }
    }
}
