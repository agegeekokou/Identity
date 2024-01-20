using IdentityWebAPI.Models.Domain;

namespace IdentityWebAPI.Services
{
    public interface IImageService
    {
        Image Upload(Image image); 
    }
}
