using Microsoft.EntityFrameworkCore;
using Moq;
using News.DataAccess.Repo.GenericRepositories;
using News.Entities;
using Xunit;

namespace News.Tests.Repositories
{
    public abstract class NegativeGenericRepoTests<T> where T : BaseEntity
    {
        protected readonly Mock<DbSet<T>> _mockDbSet;
        protected readonly Mock<DbContext> _mockDbContext;

        protected NegativeGenericRepoTests()
        {
            _mockDbSet = new Mock<DbSet<T>>();
            _mockDbContext = new Mock<DbContext>();
            _mockDbContext.Setup(e => e.Set<T>()).Returns(_mockDbSet.Object);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldThrowException_WhenEntityNotFound()
        {
            // Arrange
            var nonExistentId = Guid.NewGuid();

            _mockDbSet.Setup(m => m.FindAsync(nonExistentId))
                      .ReturnsAsync((T)null);

            var dbContextMock = new Mock<DbContext>();
            dbContextMock.Setup(db => db.Set<T>()).Returns(_mockDbSet.Object);

            var repository = new GenericRepo<T>(dbContextMock.Object);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => repository.GetByIdAsync(nonExistentId, CancellationToken.None));
        }
    }

    public class NegativGenericRepoTests_Tags : NegativeGenericRepoTests<TagEntity>
    {
        public NegativGenericRepoTests_Tags() : base()
        {
        }
    }
}