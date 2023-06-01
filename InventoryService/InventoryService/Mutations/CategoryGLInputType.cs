using GraphQL.Language.AST;
using GraphQL.Types;
using InventoryService.Models;

namespace InventoryService.Mutations
{
    public class CategoryGLInputType : InputObjectGraphType
    {
        public CategoryGLInputType()
        {
            Name = "CategoryInput";
            Field<NonNullGraphType<StringGraphType>>("CategoryName");
            Field<NonNullGraphType<DateGraphType>>("CreatedDate");
            Field<NonNullGraphType<DateGraphType>>("LastUpdatedDate");
            Field<NonNullGraphType<StringGraphType>>("CreatedBy");
            Field<NonNullGraphType<StringGraphType>>("LastUpdatedBy");

        }
    }
}