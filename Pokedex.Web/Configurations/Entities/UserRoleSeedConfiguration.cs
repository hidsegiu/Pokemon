using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pokedex.Web.Configurations.Entities
{
    internal class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "bbb7235a-02e5-47d2-a58c-484782713b7f",
                    UserId = "ddd7435a-02e5-41d2-a58c-484782713b7f"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "dbf1dc7j-cf6a-1534-9534-d4177d64c17a",
                    UserId = "daf7dc7a-cf6a-4834-9544-d4177d64b48d"
                }
             );
        }
    }
}