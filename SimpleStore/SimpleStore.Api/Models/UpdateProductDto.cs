using System.ComponentModel.DataAnnotations;

namespace SimpleStore.Api.Models
{
    public class UpdateProductDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
