using Microsoft.AspNetCore.Http;

namespace Photo.Presentation.WebPublicAPI.Model
{
    public class RegisterImage
    {
        public string FileName { get; set; }
        public IFormFile FileContent { get; set; }
    }
}
