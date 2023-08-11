using Common;

namespace Localization.Core;
public abstract class Localization: BaseDomainModel<int>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Clave { get; set; }
}
