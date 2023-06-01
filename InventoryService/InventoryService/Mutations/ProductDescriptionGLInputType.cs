using GraphQL.Types;

namespace InventoryService.Mutations
{
    public class ProductDescriptionGLInputType : InputObjectGraphType
    {
        public ProductDescriptionGLInputType()
        {
            Name = "ProductDescriptionInput";
            Field<NonNullGraphType<StringGraphType>>("Summary");
            Field<NonNullGraphType<LongGraphType>>("Cost");
            Field<NonNullGraphType<DateGraphType>>("DOP");
            Field<NonNullGraphType<DateGraphType>>("DOE");

        }
    }
}