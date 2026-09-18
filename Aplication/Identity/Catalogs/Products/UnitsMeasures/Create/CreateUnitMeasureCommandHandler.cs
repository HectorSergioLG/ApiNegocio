using Domain.Entities.Catalogs.Products.UnitsMesures;
using Domain.Primitives;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Catalogos.Products.UnitsMesures.Create
{
    internal sealed class CreateUnitMeasureCommandHandler : IRequestHandler<CreateUnitMeasureCommand, ErrorOr<Unit>>
    {
        private readonly IUnitMeasureRepository _unitMeasureRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUnitMeasureCommandHandler(IUnitMeasureRepository unitMeasureRepository, IUnitOfWork unitOfWork)
        {
            _unitMeasureRepository = unitMeasureRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<Unit>> Handle(CreateUnitMeasureCommand request, CancellationToken cancellationToken)
        {
            var unitMeasure = new UnitMeasure(
                new UnitMeasureId(Guid.NewGuid()),
                request.Name,
                request.Abbreviation,
                request.Description
            );
            _unitMeasureRepository.Add(unitMeasure);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
