using Xunit;
using Moq;
using EnigmaAPI.DataAccess;
using EnigmaAPI.Entities;
using EnigmaAPI.Services;
using EnigmaAPI.Utils.Exceptions;
using EnigmaAPI.Extensions;

public class DocumentServiceTests
{
    [Fact]
    public async Task GetClientIdAsync_Returns_ClientId()
    {
        var documentId = Guid.NewGuid();
        var tenantId = Guid.NewGuid();
        var document = new Document { Id = documentId, TenantId = tenantId, ClientId = Guid.NewGuid() };
        var documentRepoMock = new Mock<IRepository<IDocument>>();
        documentRepoMock.Setup(repo => repo.GetWhereAsync(It.IsAny<Func<IDocument, bool>>())).ReturnsAsync(document);
        var productServiceMock = new Mock<IProductService>();
        var service = new DocumentService(documentRepoMock.Object, productServiceMock.Object);

        var clientId = await service.GetClientIdAsync(tenantId, documentId);

        Assert.Equal(document.ClientId, clientId);
    }

    [Fact]
    public async Task GetClientIdAsync_Throws_NotFoundException_When_Document_Not_Found()
    {
        var documentId = Guid.NewGuid();
        var tenantId = Guid.NewGuid();
        var documentRepoMock = new Mock<IRepository<IDocument>>();
        documentRepoMock.Setup(repo => repo.GetWhereAsync(It.IsAny<Func<IDocument, bool>>())).ReturnsAsync((IDocument)null);
        var productServiceMock = new Mock<IProductService>();
        var service = new DocumentService(documentRepoMock.Object, productServiceMock.Object);

        await Assert.ThrowsAsync<NotFoundException>(() => service.GetClientIdAsync(tenantId, documentId));
    }
}
