using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace IdentityWebAPI.Services
{
    public interface ITokenService
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
