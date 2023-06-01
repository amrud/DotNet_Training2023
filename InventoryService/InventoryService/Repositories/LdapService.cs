using InventoryService.Configurations;
using InventoryService.Models;
using Microsoft.Extensions.Options;
using System.DirectoryServices;
using System.Runtime.Versioning;
using System.Text.RegularExpressions;

namespace InventoryService.Repositories
{
    [SupportedOSPlatform("windows")]
    public class LDapService : ILDapService
    {
        private const string EmailAttribute = "mail";
        private const string UserIdAttribute = "uid";
        private const string GivenNameAttribute = "givenName";
        private readonly LdapConfiguration _config;
        public LDapService(IOptions<LdapConfiguration> config)
        {
            _config = config.Value;
        }

        public User SearchUser(string userId)
        {
            if (Regex.IsMatch(userId, "^[a-zA-Z[a-zA-Z-0-9]*$"))
            {
                using (DirectoryEntry entry = new DirectoryEntry(_config.Path))
                {
                    entry.AuthenticationType = AuthenticationTypes.Anonymous;
                    using (DirectorySearcher searcher = new DirectorySearcher(entry))
                    {
                        searcher.Filter = "(&(" + UserIdAttribute + "="+ userId +"))";
                        searcher.PropertiesToLoad.Add(EmailAttribute);
                        searcher.PropertiesToLoad.Add(UserIdAttribute);
                        searcher.PropertiesToLoad.Add(GivenNameAttribute);
                        var result = searcher.FindOne();
                        if (result is not null)
                        {
                            var email = result.Properties[EmailAttribute];
                            var uid = result.Properties[UserIdAttribute];
                            var name = result.Properties[GivenNameAttribute];

                            return new User
                            {
                                Email = email is null || email.Count <= 0 ? null : email[0].ToString(),
                               UserName= name is null || name.Count <= 0 ? null : name[0].ToString(),
                                UserId= uid is null || uid.Count <= 0 ? null : uid[0].ToString(),
                            };
                        }
                    }
                }
            }

            return null;
        }


    }
}
