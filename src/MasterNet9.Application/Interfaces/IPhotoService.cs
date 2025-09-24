using MasterNet9.Application.Photos;
using Microsoft.AspNetCore.Http;

namespace MasterNet9.Application.Interfaces;

public interface IPhotoService
{
    Task<PhotoUploadResult> AddPhoto(IFormFile file);
    Task<string> DeletePhoto(string publicId);
}
