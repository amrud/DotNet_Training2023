using GraphQL.Types;
using InventoryService.Models;

namespace InventoryService.Queries
{
    public class CategoryGLType : ObjectGraphType<Category>
    {
        public CategoryGLType()
        {
            Name = "Category";
            Field(_ => _.CategoryId).Description("Category Id.");
            Field(_ => _.CategoryName).Description("Name");
            Field(_ => _.CreatedBy).Description("Created By");
            Field(_ => _.CreatedDate).Description("Created Date");
            Field(_ => _.LastUpdatedBy).Description("Last Updated By");
            Field(_ => _.LastUpdatedDate).Description("Last Updated Date");
        }
    }
}