using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace QamarKitoblar.Service.Dtos.Publishers
{
    public class PublisherCreateDto
    {
        [MaxLength(50)]
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public IFormFile ImagePath { get; set; } = default!;
        [MaxLength(13)]
        public string PhoneNumber { get; set; } = String.Empty;
    }
}
