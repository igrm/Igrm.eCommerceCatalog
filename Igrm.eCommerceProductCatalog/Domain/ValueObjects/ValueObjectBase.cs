using Igrm.eCommerceProductCatalog.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Igrm.eCommerceProductCatalog.Domain.ValueObjects
{
    public abstract class ValueObjectBase<T> where T : new()
    {
        public T GetCopy()
        {
            return (T)MemberwiseClone();
        }

        public static T Deserialize(string data)
        {
            if (!String.IsNullOrEmpty(data))
                return JsonSerializer.Deserialize<T>(data);
            return new T();
        }

        public static string Serialize(T instance)
        {
            return JsonSerializer.Serialize(instance);
        }
    }
}
