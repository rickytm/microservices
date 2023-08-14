using Common;

namespace Catalog.Core
{
    public class ProductAttribute: CatalogBase
    {        
        public virtual Product Product { get; set; }
        public Guid ProductId { get; set; }
        public virtual Category Category { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Core.Attribute Attribute { get; set; }
        public Guid AttributeId { get; set; }
        
    }
}
