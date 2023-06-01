using GraphQL.Types;
using InventoryService.Models;

namespace InventoryService.Queries
{
    public class ProductGLType : ObjectGraphType<Product>
    {

        public ProductGLType()
        {
            Name = "Product";
            Field(_ => _.ProductId).Description("Product Id");
            Field(_ => _.Name).Description("Product Name");
            Field(_ => _.SKU).Description("SKU");
            Field(_ => _.ProductDescription.Summary).Description("Summary");
            Field(_ => _.ProductDescription.Cost).Description("Cost");
            Field(_ => _.ProductDescription.DOP).Description("DOP");
            Field(_ => _.ProductDescription.DOE).Description("DOE");
        }
    }
}