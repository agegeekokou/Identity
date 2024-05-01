﻿using IdentityWebAPI.Models.Domain;
using IdentityWebAPI.Repositories;
using System.Collections.Generic;

namespace IdentityWebAPI.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IIdentityRepository repository;
        public IdentityService(IIdentityRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Identity> GetAllIdentities(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 100)
        {
            return repository.GetAllIdentities(filterOn, filterQuery, sortBy, isAscending, pageNumber, pageSize);
        }

        public Identity GetIdentityById(int id)
        {
            return repository.GetIdentityById(id);
        }

        public Identity CreateIdentity(Identity identity)
        {
            return repository.CreateIdentity(identity);
        }

        public Identity UpdateIdentity(int id, Identity identity)
        {
            return repository.UpdateIdentity(id, identity);
        }

        public Identity DeleteIdentity(int id)
        {
            return repository.DeleteIdentity(id);
        }
    }
}
