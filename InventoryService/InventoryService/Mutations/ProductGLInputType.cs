using GraphQL.Types;
using InventoryService.Models;

namespace InventoryService.Mutations
{
    public class ProductGLInputType : InputObjectGraphType
    {
        public ProductGLInputType()
        {
            Name = "ProductInput";
            Field<NonNullGraphType<StringGraphType>>("Name");
            Field<NonNullGraphType<StringGraphType>>("SKU");
            Field<NonNullGraphType<ProductDescriptionGLInputType>>("ProductDescription");

        }
    }
}