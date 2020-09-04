using Igrm.eCommerceProductCatalog.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Text.Json;

namespace Igrm.eCommerceProductCatalog.Domain.ValueObjects
{
    public class CultureCoverage : CoverageBase<CultureCoverage, CultureInfo>, IValueObject<CultureCoverage>
    {
        public CultureCoverage() : base() {}

        public static explicit operator CultureCoverage(string data)
        {
            return Deserialize(data);
        }

        public static implicit operator string(CultureCoverage cultureCoverage)
        {
            return Serialize(cultureCoverage);
        }
    }
}
