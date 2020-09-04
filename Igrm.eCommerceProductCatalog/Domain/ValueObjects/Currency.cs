using Igrm.eCommerceProductCatalog.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.eCommerceProductCatalog.Domain.ValueObjects
{
    public class Currency : ValueObjectBase<Currency>, IValueObject<Currency>
    {
        public string? Code { get; set; }

        public static explicit operator Currency(string currency)
        {
            return Deserialize(currency);
        }

        public static implicit operator string(Currency currency)
        {
            return Serialize(currency);
        }
    }
}
