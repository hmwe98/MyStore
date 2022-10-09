using MyStore.Domain.Entities.HomePages;
using Microsoft.AspNetCore.Http;

namespace MyStore.Application.Services.HomePages.AddHomePageImages
{
    public class requestAddHomePageImagesDto
    {
        public IFormFile file { get; set; }
        public string Link { get; set; }
        public ImageLocation ImageLocation{ get; set; }
    }
}
