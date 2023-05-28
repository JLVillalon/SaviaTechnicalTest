
using Application.Contracts.Persistence;
using Application.Features.Products.Queries.GetProductById;
using Application.Features.Products.ViewModels;
using Application.Mappings;
using AutoMapper;
using Infraestructure.UnitOfWork;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using UnitTests.Mocks;
using Xunit;

namespace UnitTests.Features.Product.Queries
{
    public class GetProductByIdQueryHandlerTests
    {

        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public GetProductByIdQueryHandlerTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig= new MapperConfiguration(c =>
            {
                c.AddProfile<AutoMapperProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            MockProductRepository.AddDataProductRepository(_unitOfWork.Object.ApplicationDbContext);
        }


        [Fact]
        public async Task GetProductByIdTest()
        {
            var handler = new GetProductByIdQueryHandler(_unitOfWork.Object, _mapper);
            var request = new GetProductByIdQuery(Guid.Parse("9232cee8-15a0-431c-9778-a4636e77a74e"));

            var result = await handler.Handle(request, CancellationToken.None);

            result.ShouldBeOfType<ProductViewModel>();
        }

    }
}
