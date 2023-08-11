using System.Runtime.Serialization;

namespace Catalog.Core
{
    public enum ProductStatus
    {
        [EnumMember(Value = "Producto Inactivo")]
        Inactivo,
        [EnumMember(Value = "Producto Activo")]
        Activo
    }
}
