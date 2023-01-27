using System.Net;

namespace StudentMangementPortal.API.Repository
{
    public interface IImageRepository
    {
        Task<string> Upload(IFormFile file, string fileName);
    }
}
