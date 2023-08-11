using Common;

namespace Catalog.Core
{
    public class Brand: CatalogBase
    {
        public string Nombre{get;set;}
        public virtual ICollection<Product> Products { get; set; }
    }
}
