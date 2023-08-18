using Catalog.Core;
using Common.Extensions;

namespace Catalog.Infrastructure.Data;


public class LoadData
{
    public static List<Category> GetCategories()
    {
        return new List<Category> { new Category{
            Id= Guid.Parse("cdfeeed4-6560-4a61-9460-caa9441da9af"),
            Nombre = "Café"
        } };
    }
    public static List<Brand> GetBrands()
    {
        var brandList = new List<Brand>{
            new Brand{
                Id= Guid.Parse("066de873-61af-4a15-bb29-591bdfe87d38"),
                Nombre = "Café Oaxaca"
            },
            new Brand{
                Id= Guid.Parse("7ffff15d-4cca-45f0-8931-8af9156a20fe"),
                Nombre="Café Guerrero"
            },
            new Brand{
                Id= Guid.Parse("f19d7876-6998-4228-bf00-7769de9e3fa0"),
                Nombre="Oaxaca Premium"
            },
            new Brand{
                Id= Guid.Parse("487e7492-05e6-4c31-88db-49bd85c2112a"),
                Nombre="Café Veracruz"
            },
            new Brand{
                Id= Guid.Parse("7a5b9e89-f7ee-4ed7-85c6-1980a8ab682b"),
                Nombre="Café Chiapas"
            },
            new Brand{
                Id= Guid.Parse("f13cd2e2-d13d-41a7-91f6-4794c7a44325"),
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
                Id = Guid.Parse("390d5e24-0a19-456b-acbb-c6063d9213f4"),
                CategoryId = GetCategories().First().Id,
                Key = "Molido",
                Value = "Fino"
            },
            new Core.Attribute
            {
                Id = Guid.Parse("9258f07d-c830-4593-9b24-1f5f6793e3f1"),
                CategoryId = GetCategories().First().Id,
                Key = "Molido",
                Value = "Medio"
            },
            new Core.Attribute
            {
                Id = Guid.Parse("907d262c-cc9a-450b-89ec-4cffbd6794c4"),
                CategoryId = GetCategories().First().Id,
                Key = "Molido",
                Value = "Grueso"
            },
            new Core.Attribute
            {
                Id = Guid.Parse("c09a370d-91fa-42af-828b-c9e9802835c1"),
                CategoryId = GetCategories().First().Id,
                Key = "Tipo de Grano",
                Value = "Arábiga"
            },
            new Core.Attribute
            {
                Id = Guid.Parse("9237a389-d349-4b32-9153-bd11d1d8d2ce"),
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
                Id = Guid.Parse("4fa145eb-19ce-4125-a2ae-d6fd31f61e6f"),
                Nombre="250 Grs."                
            },
            new Variant(){
                Id = Guid.Parse("511d1c01-f8f3-4ec9-bdae-3629777f00da"),
                Nombre="500 Grs."
            },
            new Variant(){
                Id = Guid.Parse("83bf82f9-d5ca-4e4b-b199-6b08c2d556c7"),
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

        return productsproducts.Select(x => { x.Id = Guid.NewGuid(); return x; }).ToList(); ;

    }
}

