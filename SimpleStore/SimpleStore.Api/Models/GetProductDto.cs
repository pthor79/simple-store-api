using System.ComponentModel.DataAnnotations;

namespace SimpleStore.Api.Models
{
    public class GetProductDto: ProductBaseDto
    {
        [Required]
        public int Id { get; set; }
    }
}
