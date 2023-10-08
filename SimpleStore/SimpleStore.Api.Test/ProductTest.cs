using Microsoft.EntityFrameworkCore;
using Moq;
using SimpleStore.Api.Contracts;
using SimpleStore.Api.Data;
using SimpleStore.Api.Models;
using SimpleStore.Api.Repositories;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace SimpleStore.Api.Test
{
    public class ProductTest
    {
        private Mock<IProductsRepository> _productRepositoryMoc;
        private List<Product> _availableProducts;

        public ProductTest()
        {
            //Arrange             
            _availableProducts = new List<Product>{
                new Product
                    {
                        Id = 1,
                        Name = "TestProduct1",
                        Description = "Description of the test product",
                        ImgUri = "http://localhost/images/test1.png",
                        Price = 10
                    },
                new Product
                    {
                        Id = 2,
                        Name = "TestProduct2",
                        Description = "Description of the test product",
                        ImgUri = "http://localhost/images/test1.png",
                        Price = 20
                    },
                new Product
                    {
                        Id = 3,
                        Name = "TestProduct1",
                        Description = "Description of the test product",
                        ImgUri = "http://localhost/images/test1.png",
                        Price = 30
                    }
            };

            _productRepositoryMoc = new Mock<IProductsRepository>();
            _productRepositoryMoc.Setup(_ => _.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(_availableProducts.First());
        }

        [Fact]
        public void ShouldReturnAvailableProducts()
        {
            //Arange
            _productRepositoryMoc.Setup(_ => _.GetAllAsync())
               .ReturnsAsync(_availableProducts);

            //Act
            var result = _productRepositoryMoc.Object.GetAllAsync();

            //Assert
            Assert.NotNull(result.Result);
            Assert.Equal(_availableProducts, result.Result);
        }

        [Theory]
        [InlineData(1, 0, 1)]
        public void ShouldReturnPagedAvailableProducts(int pageNumber, int startIndex, int pageSize)
        {
            var queryParameters = new QueryParameters
            {
                PageNumber = pageNumber,
                StartIndex = startIndex,
                PageSize = pageSize
            };

            //Arange
            _productRepositoryMoc.Setup(_ => _.GetAllAsync<Product>(queryParameters))
               .ReturnsAsync(new PagedResult<Product> {  Items = { _availableProducts.First() }, PageNumber = 1, RecordNumber = 1, TotalCount = 1 } );

            //Act
            var result = _productRepositoryMoc.Object.GetAllAsync<Product>(queryParameters);

            //Assert
            Assert.NotNull(result.Result);
            Assert.NotNull(result.Result.Items);
            Assert.Single(result.Result.Items);
            Assert.Equal(_availableProducts.First().Id, result.Result.Items.First().Id);
        }


        [Theory]
        [InlineData(1)]
        public void ShouldReturnProductWithId(int? productId)
        {
            //Arange
            _productRepositoryMoc.Setup(_ => _.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(_availableProducts.First());

            //Act
            var result = _productRepositoryMoc.Object.GetByIdAsync(productId);

            //Assert
            Assert.NotNull(result.Result);
            Assert.Equal(result.Id, productId);
        }

        [Fact]
        public void ShouldUpdateProduct()
        {
            //Arrange 
            Product updatedProduct = new Product
            {
                Id = 2,
                Name = "TestProduct2",
                Description = "Test",
                ImgUri = "http://localhost/images/test2.png",
                Price = 20
            };

            _productRepositoryMoc.Setup(_ => _.UpdateAsync(It.IsAny<Product>()))
                 .Callback<Product>(product => product.Description = updatedProduct.Description);

            //Act
            _productRepositoryMoc.Object.UpdateAsync(updatedProduct);

            //Assert
            _productRepositoryMoc.Verify(x => x.UpdateAsync(It.IsAny<Product>()), Times.Once);
        }


        [Fact]
        public void ShouldReturnCreatedProduct()
        {
            //Arrange 
            Product newProduct = new Product
            {
                Name = "TestProduct2",
                Description = "Description of the test product",
                ImgUri = "http://localhost/images/test2.png",
                Price = 20
            };

            _productRepositoryMoc.Setup(_ => _.AddAsync(It.IsAny<Product>()))
               .ReturnsAsync(newProduct);

            //Act
            var result = _productRepositoryMoc.Object.AddAsync(newProduct).Result;

            //Assert
            _productRepositoryMoc.Verify(x => x.AddAsync(It.IsAny<Product>()), Times.Once);

            Assert.NotNull(result);
            Assert.Equal(newProduct.Name, result.Name);
            Assert.Equal(newProduct.Description, result.Description);
            Assert.Equal(newProduct.Price, result.Price);
        }
    }
}