using Common;

namespace Catalog.Core
{
    public class ProductVariant:CatalogBase
    {
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
        public string ProductoNombre => Product?.Nombre ?? string.Empty;
        public string ProductoDescripcion => Product?.Descripcion ?? string.Empty;
        public virtual Variant? Variant { get; set; }
        public int VariantId { get; set; }
        public decimal Precio { get; set; }
        public string VariantNombre => Variant?.Nombre ?? string.Empty;
        public int Stock { get; set; }
    }
}
