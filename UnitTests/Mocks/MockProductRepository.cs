using AutoFixture;
using Domain;
using Infraestructure.Persistence;
using Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace UnitTests.Mocks
{
    public static class MockProductRepository
    {
        public static void AddDataProductRepository(ApplicationDbContext applicationDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var products = fixture.CreateMany<Product>().ToList();
            products.Add(fixture.Build<Product>()
                .With(tr => tr.Id, Guid.Parse("9232cee8-15a0-431c-9778-a4636e77a74e"))
                .Create());

            applicationDbContextFake.Products.AddRange(products);
            applicationDbContextFake.SaveChanges();
        }
    }
}
