using Microsoft.Extensions.Logging;

namespace Catalog.Infrastructure.Data
{
    public class ApplicationDBContextSeedData
    {
        public static async Task InitDb(ApplicationDBContext context, ILogger logger)
        {
            try
            {
                if (!context.Categories!.Any())
                {
                    var categoriesList = LoadData.GetCategories();
                    await context.AddRangeAsync(categoriesList);
                    await context.SaveChangesAsync();
                }

                if (!context.Variants!.Any())
                {
                    var variantList = LoadData.GetVariants();
                    await context.Variants!.AddRangeAsync(variantList);
                    await context.SaveChangesAsync();
                }

                if (!context.Brands!.Any())
                {
                    var brandList = LoadData.GetBrands();
                    await context.Brands!.AddRangeAsync(brandList);
                    await context.SaveChangesAsync();
                }

                if (!context.Attributes!.Any())
                {
                    var cafeAttrs = LoadData.GetAttributes();
                    await context.Attributes!.AddRangeAsync(cafeAttrs);
                    await context.SaveChangesAsync();
                }

                if (!context.Products!.Any())
                {
                    var products = LoadData.GetListProducts();
                    await context.Products!.AddRangeAsync(products);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e) 
            {
                logger.LogError(e.Message);
            }
        }
    }
}
