using Igrm.eCommerceProductCatalog.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Igrm.eCommerceProductCatalog.Domain.ValueObjects
{
    public class CurrencyCoverage : CoverageBase<CurrencyCoverage, Currency>, IValueObject<CurrencyCoverage>
    {
        public CurrencyCoverage() : base() {}

        public static explicit operator CurrencyCoverage(string currencyCoverage)
        {
            return Deserialize(currencyCoverage);
        }

        public static implicit operator string(CurrencyCoverage cultureCoverage)
        {
            return Serialize(cultureCoverage);
        }

    }
}
