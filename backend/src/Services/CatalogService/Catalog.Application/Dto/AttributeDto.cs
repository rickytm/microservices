namespace Catalog.Application.Dtos;

public class AttributeDto
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
}
