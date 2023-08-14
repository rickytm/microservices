using Catalog.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Data
{
    public class ApplicationDBContextData
    {
        public static async Task InitDB(ApplicationDBContext context, ILoggerFactory loggerFactory)
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
            catch(Exception e) 
            {
                var logger = loggerFactory.CreateLogger<ApplicationDBContextData>();
                logger.LogError(e.Message);
            }
        }
    }
}
