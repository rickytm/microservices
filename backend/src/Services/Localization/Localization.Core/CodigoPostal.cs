namespace Localization.Core;

public class CodigoPostal : Localization
{
    public Municipio Municipio { get; set; }
    public int MunicipioId { get; set; }
    public virtual ICollection<Colonia> Colonias { get; set; } = new List<Colonia>();
}
