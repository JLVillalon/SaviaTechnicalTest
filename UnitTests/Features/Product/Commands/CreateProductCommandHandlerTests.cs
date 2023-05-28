using Application.Contracts.Persistence;
using Application.Features.Products.Commands.CreateProduct;
using Application.Mappings;
using AutoMapper;
using Castle.Core.Logging;
using Infraestructure.UnitOfWork;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.Mocks;
using Xunit;

namespace UnitTests.Features.Product.Commands
{
    public class CreateProductCommandHandlerTests
    {


        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<ILogger<CreateProductCommandHandler>> _logger;


        public CreateProductCommandHandlerTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<AutoMapperProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _logger = new Mock<ILogger<CreateProductCommandHandler>>();

            MockProductRepository.AddDataProductRepository(_unitOfWork.Object.ApplicationDbContext);
        }


        [Fact]
        public async Task CreateProductCommand_InputProduct_ReturnsGuid()
        {
            var streamerInput = new CreateProductCommand
            {
                Name = "ProductNameTest",
                Description = "ProductDescriptionTest",
                PartNumber = "ProductPartNumberTest",
                Price = 10
            };

            var handler = new CreateProductCommandHandler(_logger.Object, _mapper, _unitOfWork.Object);
            var result = await handler.Handle(streamerInput, CancellationToken.None);

            result.ShouldBeOfType<Guid>();
        }
    }
}
