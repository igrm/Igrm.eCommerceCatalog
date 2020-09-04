using Igrm.eCommerceProductCatalog.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.eCommerceProductCatalog.Domain.ValueObjects
{
    public class Path : CoverageBase<Path, Guid>, IValueObject<Path>
    {
        public Path() : base()
        {
        }
   }
}
