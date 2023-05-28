using Infraestructure.Persistence;
using Infraestructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace UnitTests.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<UnitOfWork> GetUnitOfWork()
        {
            Guid dbContextId = Guid.NewGuid();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: $"ApplicationDbContext-{dbContextId}")
                .Options;

            var applicationDbContextFake = new ApplicationDbContext(options);
            applicationDbContextFake.Database.EnsureDeleted();
            var mockUnitOfWork = new Mock<UnitOfWork>(applicationDbContextFake);


            return mockUnitOfWork;
        }
    }
}
