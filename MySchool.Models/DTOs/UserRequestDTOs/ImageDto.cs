using Microsoft.AspNetCore.Http;

namespace MySchool.Models.DTOs.UserRequestDTOs
{
    public class ImageDto
    {
        public IFormFile Image { get; set; }
    }
}
