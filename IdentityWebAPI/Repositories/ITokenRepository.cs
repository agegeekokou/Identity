using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace IdentityWebAPI.Repositories
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
