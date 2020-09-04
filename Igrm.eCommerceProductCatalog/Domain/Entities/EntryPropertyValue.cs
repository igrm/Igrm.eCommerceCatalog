using Igrm.eCommerceProductCatalog.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Igrm.eCommerceProductCatalog.Domain.Entities
{
    public class EntryPropertyValue : EntityBase, IEntity
    {
        public EntryPropertyValue(Property property, string value, Entry entry, CultureInfo culture)
        {
            Property = property;
            Value = value;
            Entry = entry;
            Culture = culture;
        }

        private int _propertyId;
        [Required]
        public virtual Property? Property { get; set; }

        private int _entryId;
        [Required]
        public virtual Entry? Entry { get; set; }

        [Required]
        public string? Value { get; set; }

        private string? _culture;
        [Required]
        public CultureInfo Culture { get { return string.IsNullOrEmpty(_culture) ? CultureInfo.InvariantCulture : CultureInfo.GetCultureInfo(_culture); } private set { _culture = value.ToString(); } }
    }
}
