using GraphQL;
using GraphQL.Types;
using InventoryService.Models;
using InventoryService.Queries;
using InventoryService.Repositories;

namespace InventoryService.Mutations
{
    public class RootMutation : ObjectGraphType
    {
        private ICategoryRepo _categoryRepo;
        private IProductRepo _productRepo;

        public RootMutation(ICategoryRepo categoryRepo, IProductRepo productRepo)
        {

            _categoryRepo = categoryRepo;
            _productRepo = productRepo;

            Name = "EcommerceMutation";
            Field<CategoryGLType>("insertCategory",
            arguments: new QueryArguments(

                new QueryArgument<CategoryGLInputType> { Name = "category" }),

            resolve: context =>
            {

                var category = context.GetArgument<Category>("category");

                return InsertCategory(category);
            });

            Field<CategoryGLType>(
               "UpdateCategory",
               arguments: new QueryArguments(new QueryArgument<NonNullGraphType<LongGraphType>>
               { Name = "CategoryId" },
               new QueryArgument<NonNullGraphType<StringGraphType>>
               { Name = "CategoryName" }
               ),
               resolve: context =>
               {
                   var categoryId = context.GetArgument<long>("CategoryId");
                   var categoryName = context.GetArgument<string>("CategoryName");

                   return UpdateCategory(categoryId, categoryName);
               }
           );

            FieldAsync<StringGraphType>(
                "DeleteCategory",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<LongGraphType>>
                { Name = "CategoryId" }),
                resolve: async context =>
                {
                    var categoryId = context.GetArgument<long>("CategoryId");

                    await DeleteCategory(categoryId);

                    return $"CategoryId {categoryId} is successfully deleted";

                }
            );


            Field<ProductGLType>("insertProduct",
            arguments: new QueryArguments(

                new QueryArgument<ProductGLInputType> { Name = "product" },
                new QueryArgument<NonNullGraphType<LongGraphType>> { Name = "categoryId" }),

            resolve: context =>
            {

                var product = context.GetArgument<Product>("product");
                var categoryId = context.GetArgument<long>("categoryId");

                return InsertProduct(product, categoryId);
            });

            Field<ProductGLType>(
               "UpdateProduct",
               arguments: new QueryArguments(new QueryArgument<NonNullGraphType<LongGraphType>>
               { Name = "ProductId" },
               new QueryArgument<NonNullGraphType<LongGraphType>>
               { Name = "Cost" }
               ),
               resolve: context =>
               {
                   var productId = context.GetArgument<long>("ProductId");
                   var cost = context.GetArgument<long>("Cost");

                   return UpdateProduct(productId, cost);
               }
           );

        }

        private async Task<Category> InsertCategory(Category Category)
        {
            if (Category == null)
                return null;
            else
            {
                return await _categoryRepo.AddCategory(Category);
            }
        }

        private async Task<Category> UpdateCategory(long categoryId, string categoryName)
        {

            return await _categoryRepo.UpdateCategory(categoryId, categoryName);

        }

        private async Task<bool> DeleteCategory(long categoryId)
        {

            return await _categoryRepo.DeleteCategory(categoryId);

        }



        private async Task<Product> InsertProduct(Product Product, long CatalogId)
        {
            if (Product == null)
                return null;
            else
            {
                return await _productRepo.AddProduct(Product, CatalogId);
            }
        }
        private async Task<Product> UpdateProduct(long productId, long cost)
        {

            return await _productRepo.UpdateProduct(productId, cost);

        }
    }
}