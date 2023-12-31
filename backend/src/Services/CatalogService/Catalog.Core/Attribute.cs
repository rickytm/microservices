﻿using Common;

namespace Catalog.Core
{
    public class Attribute: CatalogBase
    {
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
