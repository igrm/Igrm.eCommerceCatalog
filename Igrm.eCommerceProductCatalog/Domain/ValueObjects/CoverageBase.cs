using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.eCommerceProductCatalog.Domain.ValueObjects
{
    public abstract class CoverageBase<T, U> : ValueObjectBase<T> where T : new()
    {
        public CoverageBase()
        {
            Items = new List<U>();
        }

        public IList<U> Items { get; private set; }

        public void AddItem(U item)
        {
            Items.Add(item);
        }
    }
}
