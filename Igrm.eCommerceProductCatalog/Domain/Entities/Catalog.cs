using Igrm.eCommerceProductCatalog.Domain.ValueObjects;
using Igrm.eCommerceProductCatalog.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace Igrm.eCommerceProductCatalog.Domain.Entities
{
    public class Catalog : EntityBase, IAggregateRoot, IEntity
    {
        [Required]
        public CultureInfo? DefaultCulture { get; set; }

        [Required]
        public string? DefaultCurrency { get; set; }

        [Required]
        public UnitOfMass? BaseUnitOfMass { get; set; }

        [Required]
        public UnitOfLength? BaseUnitOfLength { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? NameInUrl { get; set; }

        public DateTime AvailabilityDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        public IList<Entry>? Entries { get; private set; }

        public void AddEntry(Entry entry)
        {
            if (Entries == null) Entries = new List<Entry>();

            Entries.Add(entry);
        }

        public void RemoveEntry(Entry entry)
        {
            if (Entries != null) Entries.Remove(entry);
        }

    }
}
