using Common;

namespace Catalog.Core
{
    public class Product: CatalogBase
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Rating { get; set; }
        public string Vendedor { get; set; }
        public ProductStatus Status { get; set; } = ProductStatus.Activo;        
        public virtual Category Category { get; set; }
        public Guid CategoryId { get; set; }        
        public int Stock => Variants?.Sum(x => x.Stock) ?? 0;
        public virtual Brand Brand { get; set; }
        public Guid BrandId { get; set; }
        public virtual ICollection<ProductVariant> Variants { get; set; }
        public virtual ICollection<ProductAttribute> Attributes { get; set; }
    }
}
