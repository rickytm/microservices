﻿using Common;

namespace Catalog.Core
{
    public class Category: CatalogBase
    {
        public string Nombre { get; set; }
        public Guid? ParentId { get; set; }
        public virtual Category Parent { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Attribute> Attributes { get; set; }
    }
}
