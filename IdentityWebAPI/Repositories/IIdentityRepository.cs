using IdentityWebAPI.Models.Domain;
using System.Collections.Generic;

namespace IdentityWebAPI.Repositories
{
    public interface IIdentityRepository
    {
        IEnumerable<Identity> GetAllIdentities(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 100); 

        Identity GetIdentityById(int id);

        Identity CreateIdentity(Identity identity);

        Identity UpdateIdentity(int id, Identity identity);

        Identity DeleteIdentity(int id);
    }
}
