using IdentityWebAPI.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace IdentityWebAPI.Services
{
    public class TokenService : ITokenService
    {
        private readonly ITokenRepository tokenRepository;

        public TokenService(ITokenRepository tokenRepository)
        {
            this.tokenRepository = tokenRepository;
        }

        public string CreateJwtToken(IdentityUser user, List<string> roles)
        {
            return tokenRepository.CreateJwtToken(user, roles);
        }
    }
}
