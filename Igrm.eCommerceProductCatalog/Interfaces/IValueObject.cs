using Igrm.eCommerceProductCatalog.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.eCommerceProductCatalog.Interfaces
{
    public interface IValueObject<T>
    {
        T GetCopy();
    }
}
