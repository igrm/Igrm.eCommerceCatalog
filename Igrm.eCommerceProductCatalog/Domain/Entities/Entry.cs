using Igrm.eCommerceProductCatalog.Domain.ValueObjects;
using Igrm.eCommerceProductCatalog.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;

namespace Igrm.eCommerceProductCatalog.Domain.Entities
{
    public abstract class Entry : EntityBase, IEntity
    {
        private int _catalogId;
        public virtual Catalog? Catalog { get; set; }

        [Required]
        public string? Code { get; set; }

        public bool IsAvailable { get; set; }

        public int SortOrder { get; set; }

        [Required]
        public string? Name { get; set; }
        [Required]
        public string? NameInUrl { get; set; }

        public DateTime AvailabilityDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        private string? _cultureCoverage;
        [Required]
        public CultureCoverage CultureCoverage { get { return (CultureCoverage)(_cultureCoverage ?? String.Empty); } private set { _cultureCoverage = (string)value; } }

        private string? _hierarchy;
        [Required]
        public Hierarchy Hierarchy { get { return (Hierarchy)(_hierarchy ?? String.Empty); } private set { _hierarchy = (string)value; } }

        public virtual IList<EntryPropertyValue>? EntryPropertyValues { get; private set; }

        public void AddCulture(CultureInfo culture)
        {
            var copy = CultureCoverage.GetCopy();
            copy.AddItem(culture);
            CultureCoverage = copy;
        }

        private void AddPath(Path path)
        {
            var copy = Hierarchy.GetCopy();
            copy.AddItem(path);
            Hierarchy = copy;
        }

        private void RemovePath(Path path)
        {
            var copy = Hierarchy.GetCopy();
            copy.Items.Remove(path);
            Hierarchy = copy;
        }

        public void AddChildEntry(Entry childEntry)
        {
            var currentPath = Hierarchy.Items.First();
            var childEntryPath = currentPath.GetCopy();

            if (!childEntry.Hierarchy.Items.SelectMany(x=>x.Items).Contains(Id))
            {
                childEntryPath.AddItem(Id);
                childEntry.AddPath(childEntryPath);
            }
        }

        public void RemoveChildEntry(Entry childEntry)
        {
            var toRemove = childEntry.Hierarchy.Items.Where(x => x.Items.Last() == Id).Single();
            childEntry.RemovePath(toRemove);
        }

        public void AddPropertyValue(Property property, string value, CultureInfo culture)
        {
            if (EntryPropertyValues == null)  EntryPropertyValues = new List<EntryPropertyValue>();
            EntryPropertyValues.Add(new EntryPropertyValue(property, value, this, culture));
        }

        public void RemovePropertyValue(Property property, CultureInfo culture)
        {
            if (EntryPropertyValues != null)
                foreach (var item in EntryPropertyValues.Where(x=>x.Property == property).ToList())
                {
                    EntryPropertyValues.Remove(item);
                }
        }

        public IList<Entry> GetDescendants()
        {
            var result = new List<Entry>();
            
            if (Catalog != null && Hierarchy!=null)
                result = Catalog.Entries.Where(x => x.Hierarchy.Items.SelectMany(y => y.Items).Contains(this.Id)).ToList();

            return result;
        }

        public IList<Entry> GetAscendants()
        {
            var result = new List<Entry>();
            if (Catalog != null && Hierarchy != null)
                result = Catalog.Entries.Where(x=>this.Hierarchy.Items.SelectMany(x=>x.Items).Contains(x.Id)).ToList();

            return result;

        }
    }
}
