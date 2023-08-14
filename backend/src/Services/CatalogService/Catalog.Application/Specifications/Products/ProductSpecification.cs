using Common.Specifications;

namespace Catalog.Application.Specifications.Products;

public class ProductSpecification : BaseSpecification<Core.Product>
{

    public ProductSpecification(ProductSpecificationParams productParams)
        : base(
            x =>
             (string.IsNullOrEmpty(productParams.Search) || x.Nombre!.Contains(productParams.Search)
                || x.Descripcion!.Contains(productParams.Search)
             ) &&
            (!productParams.CategoryIds.Any() || productParams.CategoryIds.Contains(x.CategoryId)) &&
            (!productParams.BrandIds.Any() || productParams.BrandIds.Contains(x.BrandId)) &&
            (!productParams.Ratings.Any() || productParams.Ratings.Contains(x.Rating)) &&
            (!productParams.PrecioMin.HasValue || x.Variants!.Any(x => x.Precio >= productParams.PrecioMin)) &&
            (!productParams.PrecioMax.HasValue || x.Variants!.Any(x => x.Precio <= productParams.PrecioMax)) &&
            (!productParams.Status.HasValue || x.Status == productParams.Status) &&
            (!productParams.AttributesIds.Any() || x.Attributes!.Any(x => productParams.AttributesIds.Contains(x.AttributeId)))
        )
    {
        if (productParams.IsFromAdmin)
        {
            AddInclude(p => p.Variants!);
            AddInclude(p => p.Category!);
            AddInclude(p => p.Brand!);
        }
        else
        {
            AddInclude(p => p.Variants!);
            AddInclude(p => p.Attributes!);
            AddInclude(p => p.Category!);
            AddInclude(p => p.Brand!);
            AddInclude(p => p.Variants!);

            AddInclude("Variants.Variant");
            AddInclude("Attributes.Category");
            AddInclude("Attributes.Attribute");
        }


        ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

        if (!string.IsNullOrEmpty(productParams.Sort))
        {
            switch (productParams.Sort)
            {
                case "nombreAsc":
                    AddOrderBy(p => p.Nombre!);
                    break;

                case "nombreDesc":
                    AddOrderByDescending(p => p.Nombre!);
                    break;

                case "precioAsc":
                    AddOrderBy(p => p.Variants!.Select(x => x.Precio!));
                    break;

                case "precioDesc":
                    AddOrderByDescending(p => p.Variants!.Select(x => x.Precio!));
                    break;

                case "ratingAsc":
                    AddOrderBy(p => p.Rating!);
                    break;

                case "ratingDesc":
                    AddOrderByDescending(p => p.Rating!);
                    break;

                default:
                    AddOrderBy(p => p.CreatedDate!);
                    break;
            }
        }
        else
        {
            AddOrderBy(p => p.Id);
        }

    }

}