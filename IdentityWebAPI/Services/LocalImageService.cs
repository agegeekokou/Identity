using IdentityWebAPI.Models.Domain;
using IdentityWebAPI.Repositories;

namespace IdentityWebAPI.Services
{
    public class LocalImageService : IImageService
    {
        private readonly IImageRepository repository;
        public LocalImageService(IImageRepository repository)
        {
            this.repository = repository;
        }
        public Image Upload(Image image)
        {
            return repository.Upload(image);
        }
    }
}
