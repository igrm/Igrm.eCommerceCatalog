using Igrm.eCommerceProductCatalog.Domain.Entities;
using Igrm.eCommerceProductCatalog.Interfaces;
using System.Collections.Generic;

namespace Igrm.eCommerceProductCatalog.Domain
{
    public class Property : EntityBase, IEntity
    {
        public IList<EntryPropertyValue>? EntryPropertyValues { get; set; }
    }
}
