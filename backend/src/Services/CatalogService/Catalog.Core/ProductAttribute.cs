using Common;

namespace Catalog.Core
{
    public class ProductAttribute: CatalogBase
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int AttributeId { get; set; }
        public virtual Core.Attribute Attribute { get; set; }
    }
}
