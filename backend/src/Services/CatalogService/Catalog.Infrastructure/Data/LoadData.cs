using Catalog.Core;
using Common.Extensions;

namespace Catalog.Infrastructure.Data;


public class LoadData
{
    public static List<Category> GetCategories()
    {
        return new List<Category> { new Category{
            Id= Guid.NewGuid(),
            Nombre = "Café"
        } };
    }
    public static List<Brand> GetBrands()
    {
        var brandList = new List<Brand>{
            new Brand{
                Id= Guid.NewGuid(),
                Nombre = "Café Oaxaca"
            },
            new Brand{
                Id= Guid.NewGuid(),
                Nombre="Café Guerrero"
            },
            new Brand{
                Id= Guid.NewGuid(),
                Nombre="Oaxaca Premium"
            },
            new Brand{
                Id= Guid.NewGuid(),
                Nombre="Café Veracruz"
            },
            new Brand{
                Id= Guid.NewGuid(),
                Nombre="Café Chiapas"
            },
            new Brand{
                Id= Guid.NewGuid(),
                Nombre="Chiapas de Altura"
            }
        };

        return brandList;
    }
    public static List<Core.Attribute> GetAttributes()
    {
        var cafeAttrs = new List<Core.Attribute>
        {
            new Core.Attribute
            {
                Id = Guid.NewGuid(),
                CategoryId = GetCategories().First().Id,
                Key = "Molido",
                Value = "Fino"
            },
            new Core.Attribute
            {
                Id = Guid.NewGuid(),
                CategoryId = GetCategories().First().Id,
                Key = "Molido",
                Value = "Medio"
            },
            new Core.Attribute
            {
                Id = Guid.NewGuid(),
                CategoryId = GetCategories().First().Id,
                Key = "Molido",
                Value = "Grueso"
            },
            new Core.Attribute
            {
                Id = Guid.NewGuid(),
                CategoryId = GetCategories().First().Id,
                Key = "Tipo de Grano",
                Value = "Arábiga"
            },
            new Core.Attribute
            {
                Id = Guid.NewGuid(),
                CategoryId = GetCategories().First().Id,
                Key = "Tipo de Grano",
                Value = "Rodusta"
            }
        };

        return cafeAttrs;
    }
    public static List<Variant> GetVariants()
    {
        return new List<Variant>() {
            new Variant(){
                Id = Guid.NewGuid(),
                Nombre="250 Grs."                
            },
            new Variant(){
                Id = Guid.NewGuid(),
                Nombre="500 Grs."
            },
            new Variant(){
                Id = Guid.NewGuid(),
                Nombre="1 Kg."
            }
        };
    }

    public static List<Product> GetListProducts()
    {
        List<Product> productsproducts = new List<Product>()
        {
            new Product()
            {
                Nombre = "Café Colombiano",
                Descripcion = "Café de alta calidad de Colombia",
                CategoryId = GetCategories().First().Id, // Asignar la categoría correspondiente
                BrandId = GetBrands().Random().Id, // Asignar la marca correspondiente
                Vendedor="ACOFI",
                Rating=5,
                Variants = GetVariants().Select(x => new ProductVariant{
                    Id = Guid.NewGuid(),
                    Precio = x.Nombre == "250 Grs." ? 80 : x.Nombre == "500 Grs." ? 150 : 250,
                    VariantId = x.Id,
                    Stock = x.Nombre == "250 Grs." ? 8 : x.Nombre == "500 Grs." ? 15 : 25,
                }).ToList(),
                Attributes= new List<ProductAttribute>(){
                    new ProductAttribute(){
                        Id = Guid.NewGuid(),
                        CategoryId = GetCategories().First().Id,
                        AttributeId = GetAttributes().First(c => c.Value == "Fino").Id
                    },
                    new ProductAttribute(){
                        CategoryId = GetCategories().First().Id,
                        AttributeId = GetAttributes().First(c => c.Value == "Arábiga").Id
                    }
                }
            },
            new Product()
            {
                Nombre = "Café Mexicano",
                Descripcion = "Café de altura de México",
                CategoryId = GetCategories().First().Id, // Asignar la categoría correspondiente
                BrandId = GetBrands().Random().Id, // Asignar la marca correspondiente
                Vendedor="ACOFI",
                Rating=5,
                Variants = GetVariants().Select(x => new ProductVariant{
                    Id = Guid.NewGuid(),
                    Precio = x.Nombre == "250 Grs." ? 80 : x.Nombre == "500 Grs." ? 150 : 250,
                    VariantId = x.Id,
                    Stock = x.Nombre == "250 Grs." ? 8 : x.Nombre == "500 Grs." ? 15 : 25,
                }).ToList(),
                Attributes= new List<ProductAttribute>(){
                    new ProductAttribute(){
                        CategoryId = GetCategories().First().Id,
                        AttributeId = GetAttributes().First(c => c.Value == "Fino").Id
                    },
                    new ProductAttribute(){
                        CategoryId = GetCategories().First().Id,
                        AttributeId = GetAttributes().First(c => c.Value == "Arábiga").Id
                    }
                }
            },
            new Product()
            {
                Nombre = "Café Guatemalteco",
                Descripcion = "Café de calidad premium de Guatemala",
                CategoryId = GetCategories().First().Id, // Asignar la categoría correspondiente
                BrandId = GetBrands().Random().Id, // Asignar la marca correspondiente
                Vendedor="ACOFI",
                Rating=5,
                Variants = GetVariants().Select(x => new ProductVariant{
                    Id = Guid.NewGuid(),
                    Precio = x.Nombre == "250 Grs." ? 80 : x.Nombre == "500 Grs." ? 150 : 250,
                    VariantId = x.Id,
                    Stock = x.Nombre == "250 Grs." ? 8 : x.Nombre == "500 Grs." ? 15 : 25,
                }).ToList(),
                Attributes= new List<ProductAttribute>(){
                    new ProductAttribute(){
                        CategoryId = GetCategories().First().Id,
                        AttributeId = GetAttributes().First(c => c.Value == "Medio").Id
                    },
                    new ProductAttribute(){
                        CategoryId = GetCategories().First().Id,
                        AttributeId = GetAttributes().First(c => c.Value == "Arábiga").Id
                    }
                }
            },
            new Product()
            {
                Nombre = "Café Peruano",
                Descripcion = "Café orgánico de Perú",
                CategoryId = GetCategories().First().Id, // Asignar la categoría correspondiente
                BrandId = GetBrands().Random().Id, // Asignar la marca correspondiente
                Vendedor="ACOFI",
                Rating=5,
                 Variants = GetVariants().Select(x => new ProductVariant{
                    Id = Guid.NewGuid(),
                    Precio = x.Nombre == "250 Grs." ? 80 : x.Nombre == "500 Grs." ? 150 : 250,
                    VariantId = x.Id,
                    Stock = x.Nombre == "250 Grs." ? 8 : x.Nombre == "500 Grs." ? 15 : 25,
                }).ToList(),
                Attributes= new List<ProductAttribute>(){
                    new ProductAttribute(){
                        CategoryId = GetCategories().First().Id,
                        AttributeId = GetAttributes().First(c => c.Value == "Grueso").Id
                    },
                    new ProductAttribute(){
                        CategoryId = GetCategories().First().Id,
                        AttributeId = GetAttributes().First(c => c.Value == "Arábiga").Id
                    }
                }

            },
            new Product()
            {
                Nombre = "Café Brasileño",
                Descripcion = "Café clásico de Brasil",
                CategoryId = GetCategories().First().Id, // Asignar la categoría correspondiente
                BrandId = GetBrands().Random().Id, // Asignar la marca correspondiente
                Vendedor="ACOFI",
                Rating=5,
               Variants = GetVariants().Select(x => new ProductVariant{
                    Id = Guid.NewGuid(),
                    Precio = x.Nombre == "250 Grs." ? 80 : x.Nombre == "500 Grs." ? 150 : 250,
                    VariantId = x.Id,
                    Stock = x.Nombre == "250 Grs." ? 8 : x.Nombre == "500 Grs." ? 15 : 25,
                }).ToList(),
                Attributes= new List<ProductAttribute>(){
                    new ProductAttribute(){
                        CategoryId = GetCategories().First().Id,
                        AttributeId = GetAttributes().First(c => c.Value == "Fino").Id
                    },
                    new ProductAttribute(){
                        CategoryId = GetCategories().First().Id,
                        AttributeId = GetAttributes().First(c => c.Value == "Arábiga").Id
                    }
                }
            },
            new Product()
            {
                Nombre = "Café Ecuatoriano",
                Descripcion = "Café orgánico de la sierra de Ecuador",
                CategoryId = GetCategories().First().Id, // Asignar la categoría correspondiente
                BrandId = GetBrands().Random().Id, // Asignar la marca correspondiente
                Vendedor="ACOFI",
                Rating=5,
                Variants = GetVariants().Select(x => new ProductVariant{
                    Id = Guid.NewGuid(),
                    Precio = x.Nombre == "250 Grs." ? 80 : x.Nombre == "500 Grs." ? 150 : 250,
                    VariantId = x.Id,
                    Stock = x.Nombre == "250 Grs." ? 8 : x.Nombre == "500 Grs." ? 15 : 25,
                }).ToList(),
                Attributes= new List<ProductAttribute>(){
                    new ProductAttribute(){
                        CategoryId = GetCategories().First().Id,
                        AttributeId = GetAttributes().First(c => c.Value == "Grueso").Id
                    },
                    new ProductAttribute(){
                        CategoryId = GetCategories().First().Id,
                        AttributeId = GetAttributes().First(c => c.Value == "Arábiga").Id
                    }
                }
            },
            new Product()
            {
                Nombre = "Café Costarricense",
                Descripcion = "Café de la región de Tarrazú",
                CategoryId = GetCategories().First().Id, // Asignar la categoría correspondiente
                BrandId = GetBrands().Random().Id, // Asignar la marca correspondiente
                Vendedor="ACOFI",
                Rating=5,
                Variants = GetVariants().Select(x => new ProductVariant{
                    Id = Guid.NewGuid(),
                    Precio = x.Nombre == "250 Grs." ? 80 : x.Nombre == "500 Grs." ? 150 : 250,
                    VariantId = x.Id,
                    Stock = x.Nombre == "250 Grs." ? 8 : x.Nombre == "500 Grs." ? 15 : 25,
                }).ToList(),
                Attributes= new List<ProductAttribute>(){
                    new ProductAttribute(){
                        CategoryId = GetCategories().First().Id,
                        AttributeId = GetAttributes().First(c => c.Value == "Fino").Id
                    },
                    new ProductAttribute(){
                        CategoryId = GetCategories().First().Id,
                        AttributeId = GetAttributes().First(c => c.Value == "Arábiga").Id
                    }
                }
            },
            new Product()
            {
                Nombre = "Café Colombiano",
                Descripcion = "Café de la región de Huila",
                CategoryId = GetCategories().First().Id, // Asignar la categoría correspondiente
                BrandId = GetBrands().Random().Id, // Asignar la marca correspondiente
                Vendedor="ACOFI",
                Rating=5,
                Variants = GetVariants().Select(x => new ProductVariant{
                    Id = Guid.NewGuid(),
                    Precio = x.Nombre == "250 Grs." ? 80 : x.Nombre == "500 Grs." ? 150 : 250,
                    VariantId = x.Id,
                    Stock = x.Nombre == "250 Grs." ? 8 : x.Nombre == "500 Grs." ? 15 : 25,
                }).ToList(),
                Attributes= new List<ProductAttribute>(){
                    new ProductAttribute(){
                        CategoryId = GetCategories().First().Id,
                        AttributeId = GetAttributes().First(c => c.Value == "Grueso").Id
                    },
                    new ProductAttribute(){
                        CategoryId = GetCategories().First().Id,
                        AttributeId = GetAttributes().First(c => c.Value == "Arábiga").Id
                    }
                }
            },
            new Product()
            {
                Nombre = "Café Brasileño",
                Descripcion = "Café de la región de Minas Gerais",
                CategoryId = GetCategories().First().Id, // Asignar la categoría correspondiente
                BrandId = GetBrands().Random().Id, // Asignar la marca correspondiente
                Vendedor="ACOFI",
                Rating=5,
                Variants = GetVariants().Select(x => new ProductVariant{
                    Id = Guid.NewGuid(),
                    Precio = x.Nombre == "250 Grs." ? 80 : x.Nombre == "500 Grs." ? 150 : 250,
                    VariantId = x.Id,
                    Stock = x.Nombre == "250 Grs." ? 8 : x.Nombre == "500 Grs." ? 15 : 25,
                }).ToList(),
                Attributes= new List<ProductAttribute>(){
                    new ProductAttribute(){
                        CategoryId = GetCategories().First().Id,
                        AttributeId = GetAttributes().First(c => c.Value == "Fino").Id
                    },
                    new ProductAttribute(){
                        CategoryId = GetCategories().First().Id,
                        AttributeId = GetAttributes().First(c => c.Value == "Arábiga").Id
                    }
                }
            },
            new Product()
            {
                Nombre = "Café Guatemalteco",
                Descripcion = "Café de la región de Antigua",
                CategoryId = GetCategories().First().Id, // Asignar la categoría correspondiente
                BrandId = GetBrands().Random().Id, // Asignar la marca correspondiente
                Vendedor="ACOFI",
                Rating=5,
                Variants = GetVariants().Select(x => new ProductVariant{
                    Id = Guid.NewGuid(),
                    Precio = x.Nombre == "250 Grs." ? 80 : x.Nombre == "500 Grs." ? 150 : 250,
                    VariantId = x.Id,
                    Stock = x.Nombre == "250 Grs." ? 8 : x.Nombre == "500 Grs." ? 15 : 25,
                }).ToList(),
                Attributes= new List<ProductAttribute>(){
                    new ProductAttribute(){
                        CategoryId = GetCategories().First().Id,
                        AttributeId = GetAttributes().First(c => c.Value == "Medio").Id
                    },
                    new ProductAttribute(){
                        CategoryId = GetCategories().First().Id,
                        AttributeId = GetAttributes().First(c => c.Value == "Arábiga").Id
                    }
                }
            },

            new Product()
            {
                Nombre = "Café Etiópico",
                Descripcion = "Café de la región de Yirgacheffe",
                CategoryId = GetCategories().First().Id, // Asignar la categoría correspondiente
                BrandId = GetBrands().Random().Id, // Asignar la marca correspondiente
                Vendedor="ACOFI",
                Rating=5,
                Variants = GetVariants().Select(x => new ProductVariant{
                    Id = Guid.NewGuid(),
                    Precio = x.Nombre == "250 Grs." ? 80 : x.Nombre == "500 Grs." ? 150 : 250,
                    VariantId = x.Id,
                    Stock = x.Nombre == "250 Grs." ? 8 : x.Nombre == "500 Grs." ? 15 : 25,
                }).ToList(),
                Attributes= new List<ProductAttribute>(){
                    new ProductAttribute(){
                        CategoryId = GetCategories().First().Id,
                        AttributeId = GetAttributes().First(c => c.Value == "Fino").Id
                    },
                    new ProductAttribute(){
                        CategoryId = GetCategories().First().Id,
                        AttributeId = GetAttributes().First(c => c.Value == "Arábiga").Id
                    }
                }
            },
            new Product()
            {
                Nombre = "Café Colombiano",
                Descripcion = "Café de la región de Huila",
                CategoryId = GetCategories().First().Id,
                BrandId = GetBrands().Random().Id,
                Vendedor="ACOFI",
                Rating=5,
                Variants = GetVariants().Select(x => new ProductVariant{
                    Id = Guid.NewGuid(),
                    Precio = x.Nombre == "250 Grs." ? 80 : x.Nombre == "500 Grs." ? 150 : 250,
                    VariantId = x.Id,
                    Stock = x.Nombre == "250 Grs." ? 8 : x.Nombre == "500 Grs." ? 15 : 25,
                }).ToList(),
                Attributes= new List<ProductAttribute>(){
                    new ProductAttribute(){
                        CategoryId = GetCategories().First().Id,
                        AttributeId = GetAttributes().First(c => c.Value == "Grueso").Id
                    },
                    new ProductAttribute(){
                        CategoryId = GetCategories().First().Id,
                        AttributeId = GetAttributes().First(c => c.Value == "Arábiga").Id
                    }
                }
            },
            new Product()
            {
                Nombre = "Café Guatemalteco",
                Descripcion = "Café de la región de Antigua",
                CategoryId = GetCategories().First().Id,
                BrandId = GetBrands().Random().Id,
                Vendedor="ACOFI",
                Rating=5,
                Variants = GetVariants().Select(x => new ProductVariant{
                    Id = Guid.NewGuid(),
                    Precio = x.Nombre == "250 Grs." ? 80 : x.Nombre == "500 Grs." ? 150 : 250,
                    VariantId = x.Id,
                    Stock = x.Nombre == "250 Grs." ? 8 : x.Nombre == "500 Grs." ? 15 : 25,
                }).ToList(),
                Attributes= new List<ProductAttribute>(){
                    new ProductAttribute(){
                        CategoryId = GetCategories().First().Id,
                        AttributeId = GetAttributes().First(c => c.Value == "Medio").Id
                    },
                    new ProductAttribute(){
                        CategoryId = GetCategories().First().Id,
                        AttributeId = GetAttributes().First(c => c.Value == "Arábiga").Id
                    }
                }
            },
            new Product()
            {
                Nombre = "Café Peruano",
                Descripcion = "Café de la región de Cajamarca",
                CategoryId = GetCategories().First().Id,
                BrandId = GetBrands().Random().Id,
                Vendedor="ACOFI",
                Rating=5,
                Variants = GetVariants().Select(x => new ProductVariant{
                    Id = Guid.NewGuid(),
                    Precio = x.Nombre == "250 Grs." ? 80 : x.Nombre == "500 Grs." ? 150 : 250,
                    VariantId = x.Id,
                    Stock = x.Nombre == "250 Grs." ? 8 : x.Nombre == "500 Grs." ? 15 : 25,
                }).ToList(),
                Attributes= new List<ProductAttribute>(){
                    new ProductAttribute(){
                        CategoryId = GetCategories().First().Id,
                        AttributeId = GetAttributes().First(c => c.Value == "Fino").Id
                    },
                    new ProductAttribute(){
                        CategoryId = GetCategories().First().Id,
                        AttributeId = GetAttributes().First(c => c.Value == "Arábiga").Id
                    }
                }
            },
            new Product()
            {
                Nombre = "Café Brasileño",
                Descripcion = "Café de la región de Minas Gerais",
                CategoryId = GetCategories().First().Id,
                BrandId = GetBrands().Random().Id,
                Vendedor="ACOFI",
                Rating=5,
                Variants = GetVariants().Select(x => new ProductVariant{
                    Id = Guid.NewGuid(),
                    Precio = x.Nombre == "250 Grs." ? 80 : x.Nombre == "500 Grs." ? 150 : 250,
                    VariantId = x.Id,
                    Stock = x.Nombre == "250 Grs." ? 8 : x.Nombre == "500 Grs." ? 15 : 25,
                }).ToList(),
                Attributes= new List<ProductAttribute>(){
                    new ProductAttribute(){
                        CategoryId = GetCategories().First().Id,
                        AttributeId = GetAttributes().First(c => c.Value == "Medio").Id
                    },
                    new ProductAttribute(){
                        CategoryId = GetCategories().First().Id,
                        AttributeId = GetAttributes().First(c => c.Value == "Arábiga").Id
                    }
                }
            },
            new Product()
            {
                Nombre = "Café Ecuatoriano",
                Descripcion = "Café de la región de Loja",
                CategoryId = GetCategories().First().Id,
                BrandId = GetBrands().Random().Id,
                Vendedor="ACOFI",
                Rating=5,
                Variants = GetVariants().Select(x => new ProductVariant{
                    Id = Guid.NewGuid(),
                    Precio = x.Nombre == "250 Grs." ? 80 : x.Nombre == "500 Grs." ? 150 : 250,
                    VariantId = x.Id,
                    Stock = x.Nombre == "250 Grs." ? 8 : x.Nombre == "500 Grs." ? 15 : 25,
                }).ToList(),
                Attributes = new List<ProductAttribute>(){
                    new ProductAttribute(){
                        CategoryId = GetCategories().First().Id,
                        AttributeId = GetAttributes().First(c => c.Value == "Grueso").Id
                    },
                    new ProductAttribute(){
                        CategoryId = GetCategories().First().Id,
                        AttributeId = GetAttributes().First(c => c.Value == "Arábiga").Id
                    }
                }
            },
            new Product()
            {
                Nombre = "Café Blue Mountain",
                Descripcion = "Café cultivado en las montañas de Jamaica",
                CategoryId = GetCategories().First().Id,
                BrandId = GetBrands().Random().Id,
                Vendedor="ACOFI",
                Rating=4,
                Variants = GetVariants().Select(x => new ProductVariant{
                    Id = Guid.NewGuid(),
                    Precio = x.Nombre == "250 Grs." ? 80 : x.Nombre == "500 Grs." ? 150 : 250,
                    VariantId = x.Id,
                    Stock = x.Nombre == "250 Grs." ? 8 : x.Nombre == "500 Grs." ? 15 : 25,
                }).ToList(),
                Attributes= new List<ProductAttribute>(){
                    new ProductAttribute(){
                        CategoryId = GetCategories().First().Id,
                        AttributeId = GetAttributes().First(c => c.Value == "Fino").Id
                    },
                    new ProductAttribute(){
                        CategoryId = GetCategories().First().Id,
                        AttributeId = GetAttributes().First(c => c.Value == "Arábiga").Id
                    }
                }
            },
            new Product()
            {
                Nombre = "Café hawaiano Kona",
                Descripcion = "Café de la región de Kona en la Isla Grande de Hawái",
                CategoryId = GetCategories().First().Id,
                BrandId = GetBrands().Random().Id,
                Vendedor="ACOFI",
                Rating=4,
                Variants = GetVariants().Select(x => new ProductVariant{
                    Id = Guid.NewGuid(),
                    Precio = x.Nombre == "250 Grs." ? 80 : x.Nombre == "500 Grs." ? 150 : 250,
                    VariantId = x.Id,
                    Stock = x.Nombre == "250 Grs." ? 8 : x.Nombre == "500 Grs." ? 15 : 25,
                }).ToList(),
                Attributes= new List<ProductAttribute>(){
                    new ProductAttribute(){
                        CategoryId = GetCategories().First().Id,
                        AttributeId = GetAttributes().First(c => c.Value == "Medio").Id
                    },
                    new ProductAttribute(){
                        CategoryId = GetCategories().First().Id,
                        AttributeId = GetAttributes().First(c => c.Value == "Arábiga").Id
                    }
                }
            },
        };

        return productsproducts;

    }
}

