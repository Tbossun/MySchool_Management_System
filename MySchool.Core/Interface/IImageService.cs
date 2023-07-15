using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MySchool.Core.Interface
{
    public interface IImageService
    {
        Task<UploadResult> ImageUploadAsync(IFormFile image);
    }
}