namespace Catalog.Application.Dtos;

public class CategoryDto
{
    public Guid Id { get; set; }
    public Guid? ParentId { get; set; }
    public string ParentName { get; set; }
    public string Nombre { get; set; }
    public virtual ICollection<AttributeDto> Attributes { get; set; }
    public virtual ICollection<AttributeGroupedDto> AttributesGrouped { get; set; }
}
