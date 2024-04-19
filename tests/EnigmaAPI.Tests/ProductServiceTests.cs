using Xunit;
using Moq;
using EnigmaAPI.DataAccess;
using EnigmaAPI.Entities;
using EnigmaAPI.Services;

public class ProductServiceTests
{
    [Fact]
    public async Task ListAllAsync_Returns_All_Products()
    {
        var products = new List<IProduct> { new Mock<IProduct>().Object, new Mock<IProduct>().Object };
        var productRepoMock = new Mock<IRepository<IProduct>>();
        productRepoMock.Setup(repo => repo.GetAllWhereAsync(It.IsAny<Func<IProduct, bool>>())).ReturnsAsync(products);
        var service = new ProductService(productRepoMock.Object);

        var result = await service.ListAllAsync();

        Assert.Equal(products, result);
    }

    [Fact]
    public async Task GetByProductCodeAsync_Returns_Product_By_Code()
    {
        var productCode = "ABC123";
        var product = new Mock<IProduct>();
        var productRepoMock = new Mock<IRepository<IProduct>>();
        productRepoMock.Setup(repo => repo.GetWhereAsync(It.IsAny<Func<IProduct, bool>>())).ReturnsAsync(product.Object);
        var service = new ProductService(productRepoMock.Object);

        var result = await service.GetByProductCodeAsync(productCode);

        Assert.Equal(product.Object, result);
    }

    [Fact]
    public async Task IsProductSupportedAsync_Returns_True_When_Product_Found()
    {
        var productCode = "ABC123";
        var product = new Mock<IProduct>();
        var productRepoMock = new Mock<IRepository<IProduct>>();
        productRepoMock.Setup(repo => repo.GetWhereAsync(It.IsAny<Func<IProduct, bool>>())).ReturnsAsync(product.Object);
        var service = new ProductService(productRepoMock.Object);

        var result = await service.IsProductSupportedAsync(productCode);

        Assert.False(result);
    }

    [Fact]
    public async Task IsProductSupportedAsync_Returns_False_When_Product_Not_Found()
    {
        var productCode = "ABC123";
        var productRepoMock = new Mock<IRepository<IProduct>>();
        productRepoMock.Setup(repo => repo.GetWhereAsync(It.IsAny<Func<IProduct, bool>>())).ReturnsAsync((IProduct)null);
        var service = new ProductService(productRepoMock.Object);

        var result = await service.IsProductSupportedAsync(productCode);

        Assert.False(result);
    }

}
