using GraphQL.Types;
using InventoryService.Mutations;
using InventoryService.Queries;

namespace InventoryService.Schemas
{
    public class InventorySchema : Schema
    {
        public InventorySchema(IServiceProvider serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<RootQuery>();
            Mutation = serviceProvider.GetRequiredService<RootMutation>();
        }
    }
}
