using Common;

namespace Catalog.Core
{
    public class Category: CatalogBase
    {
        public string Nombre { get; set; }
        public int? ParentId { get; set; }
        public virtual Category Parent { get; set; }
    }
}
