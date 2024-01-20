using IdentityWebAPI.Models.Domain;

namespace IdentityWebAPI.Repositories
{
    public interface IImageRepository
    {
        Image Upload(Image image);
    }
}
