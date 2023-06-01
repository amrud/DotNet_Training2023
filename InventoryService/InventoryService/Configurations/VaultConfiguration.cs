using VaultSharp;
using VaultSharp.V1.AuthMethods;
using VaultSharp.V1.AuthMethods.Token;

namespace InventoryService.Configurations
{
    public class VaultConfiguration
    {
        private readonly IConfiguration _configuration;
        public VaultConfiguration(IConfiguration configuration)
        {
            _configuration= configuration;
        }

        public async Task<Dictionary<string, object>> GetConfigurations(string vault)
        {
            var rootKey = _configuration["Root_Token"];
            var url = _configuration["Vault_Url"];
            IAuthMethodInfo authMethod = new TokenAuthMethodInfo(rootKey);

            var vaultClientsettings = new VaultClientSettings(url, authMethod);
            IVaultClient vaultClient = new VaultClient(vaultClientsettings);
            Console.WriteLine(vaultClient.V1.Secrets);

            var result = await vaultClient.V1.Secrets.KeyValue.V1.ReadSecretAsync(vault, "secret", null);
            return result.Data;

        }
    }
}
