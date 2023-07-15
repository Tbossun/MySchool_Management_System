using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MySchool.Utilities.ImageUpload.Interface
{
    public interface IImageService
    {
        Task<UploadResult> ImageUploadAsync(IFormFile image);
    }
}