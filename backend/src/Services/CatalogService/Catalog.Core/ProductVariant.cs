using Common;

namespace Catalog.Core
{
    public class ProductVariant:CatalogBase
    {
        public virtual Product Product { get; set; }
        public Guid ProductId { get; set; }        
        public string ProductoNombre => Product?.Nombre ?? string.Empty;
        public string ProductoDescripcion => Product?.Descripcion ?? string.Empty;
        public virtual Variant Variant { get; set; }
        public Guid VariantId { get; set; }
        public decimal Precio { get; set; }
        public string VariantNombre => Variant?.Nombre ?? string.Empty;
        public int Stock { get; set; }
    }
}
