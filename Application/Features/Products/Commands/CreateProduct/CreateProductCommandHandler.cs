using Application.Contracts.Persistence;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        #region Fields

        private readonly ILogger<CreateProductCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        #endregion


        #region Constructor

        public CreateProductCommandHandler(ILogger<CreateProductCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        #endregion


        #region Methods

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productEntity = _mapper.Map<Product>(request);
            productEntity.Id = Guid.NewGuid();

            _unitOfWork.Products.AddEntity(productEntity);
            var result = await _unitOfWork.SaveAsync();

            if (result <= 0) throw new Exception($"Unable to insert product record");

            _logger.LogInformation($"Product whit ID:{productEntity.Id}, has been successfully created");
            return productEntity.Id;
        }

        #endregion


    }
}
