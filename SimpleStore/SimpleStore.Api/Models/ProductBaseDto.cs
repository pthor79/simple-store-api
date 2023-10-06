using System.ComponentModel.DataAnnotations;

namespace SimpleStore.Api.Models
{
    public class ProductBaseDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string ImgUri { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
