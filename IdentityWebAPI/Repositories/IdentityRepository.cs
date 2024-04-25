using IdentityWebAPI.Data;
using IdentityWebAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace IdentityWebAPI.Repositories
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly IdentityDataContext dataContext;
        public IdentityRepository(IdentityDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IEnumerable<Identity> GetAllIdentities()
        {
            return dataContext.Identities.Include(i => i.Image).ToList();
        }

        public Identity GetIdentityById(int id)
        {
            return dataContext.Identities.Include(i => i.Image).FirstOrDefault(i => i.Id == id);
        }

        public Identity CreateIdentity(Identity identity)
        {
            dataContext.Identities.Add(identity);
            dataContext.SaveChanges();

            return identity;
        }

        public Identity UpdateIdentity(int id, Identity identity)
        {
            var identityData = dataContext.Identities.Include(i => i.Image).FirstOrDefault(x => x.Id == id);

            if(identityData == null)
            {
                return null;
            }

            identityData.Name = identity.Name;
            identityData.Age = identity.Age;
            identityData.City = identity.City;
            identityData.Image = identity.Image;

            dataContext.SaveChanges();

            return identityData;
        }

        public Identity DeleteIdentity(int id)
        {
            var identity = dataContext.Identities.Include(i => i.Image).FirstOrDefault(x => x.Id == id);

            if(identity == null)
            {
                return null;
            }

            dataContext.Identities.Remove(identity);
            dataContext.SaveChanges();

            return identity;
        }
    }
}
