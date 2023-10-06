using Microsoft.EntityFrameworkCore;
using SimpleStore.Api.Data;

public class SimpleStoreDbContext : DbContext
{
    public SimpleStoreDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                ImgUri = "/images/products/Glasses.png",
                Name = "Glasses",
                Price = 50
            },
            new Product
            {
                Id = 2,
                Name = "Board",
                Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                Price = 200,
                ImgUri = "/images/products/Board.png",
            },
            new Product
            {
                Id = 3,
                Name = "Shoes",
                Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                Price = 300,
                ImgUri = "/images/products/Shoes.png",
            },
            new Product
            {
                Id = 4,
                Name = "Gloves",
                Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                Price = 100,
                ImgUri = "/images/products/Gloves.png",
            },
            new Product
            {
                Id = 5,
                Name = "Helmet",
                Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                Price = 500,
                ImgUri = "/images/products/Helmet.png",
            },
            new Product
            {
                Id = 6,
                Name = "Pants",
                Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                Price = 600,
                ImgUri = "/images/products/Pants.png",
            },
            new Product
            {
                Id = 7,
                Name = "Jacket",
                Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                Price = 700,
                ImgUri = "/images/products/Jacket.png",
            }
        );
    }
}