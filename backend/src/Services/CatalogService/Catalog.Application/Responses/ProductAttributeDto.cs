namespace Catalog.Application.Responses;

public class ProductAttributeDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid AttributeId { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
    public string ProductName { get; set; }
    public string CategoryName { get; set; }
}