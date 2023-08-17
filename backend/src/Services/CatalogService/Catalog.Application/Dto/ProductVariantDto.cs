namespace Catalog.Application.Dtos;

public class ProductVariantDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Guid VariantId { get; set; }
    public decimal Precio { get; set; }
    public string VariantNombre { get; set; }
    public int Stock { get; set; }
    public string StockLabel => Stock > 0 ? "Disponible" : "Agotado";
}