namespace Localization.Core;

public class Pais : Localization
{
    public virtual ICollection<Estado> Estados { get; set; } = new List<Estado>();
}
