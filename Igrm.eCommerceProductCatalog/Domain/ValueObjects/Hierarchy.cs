using Igrm.eCommerceProductCatalog.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Igrm.eCommerceProductCatalog.Domain.ValueObjects
{
    public class Hierarchy : CoverageBase<Hierarchy, Path>, IValueObject<Hierarchy>
    {
        public Hierarchy() : base() { }

        public static explicit operator Hierarchy(string hierarchy)
        {
            return Deserialize(hierarchy);
        }

        public static implicit operator string(Hierarchy hierarchy)
        {
            return Serialize(hierarchy);
        }
    }
}
