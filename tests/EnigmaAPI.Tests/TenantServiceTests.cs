using Xunit;
using Moq;
using EnigmaAPI.DataAccess;
using EnigmaAPI.Entities;
using EnigmaAPI.Services;
using EnigmaAPI.Utils.Exceptions;

public class TenantServiceTests
{
    [Fact]
    public async Task GetTenantAsync_Returns_Tenant()
    {
        var tenantId = Guid.NewGuid();
        var tenant = new Mock<ITenant>();
        var tenantRepoMock = new Mock<IRepository<ITenant>>();
        tenantRepoMock.Setup(repo => repo.GetWhereAsync(It.IsAny<Func<ITenant, bool>>())).ReturnsAsync(tenant.Object);
        var whitelistServiceMock = new Mock<ITenantWhitelistService>();
        var service = new TenantService(tenantRepoMock.Object, whitelistServiceMock.Object);

        var result = await service.GetTenantAsync(tenantId);

        Assert.Equal(tenant.Object, result);
    }

    [Fact]
    public async Task GetTenantAsync_Throws_NotFoundException_When_Tenant_Not_Found()
    {
        var tenantId = Guid.NewGuid();
        var tenantRepoMock = new Mock<IRepository<ITenant>>();
        tenantRepoMock.Setup(repo => repo.GetWhereAsync(It.IsAny<Func<ITenant, bool>>())).ReturnsAsync((ITenant)null);
        var whitelistServiceMock = new Mock<ITenantWhitelistService>();
        var service = new TenantService(tenantRepoMock.Object, whitelistServiceMock.Object);

        await Assert.ThrowsAsync<NotFoundException>(() => service.GetTenantAsync(tenantId));
    }

}
