using Aplication.Identity.Catalogos.Products.UnitsMeasures.Common;
using Domain.Entities.Catalogs.Products.UnitsMesures;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Catalogos.Products.UnitsMeasures.GetAll
{
    public sealed class GetAllUnitMeasureQueryHandler : IRequestHandler<GetAllUnitMeasureQuery, ErrorOr<IReadOnlyList<UnitMeasureResponse>>>
    {
        private readonly IUnitMeasureRepository _unitMeasureRepository;

        public GetAllUnitMeasureQueryHandler(IUnitMeasureRepository unitMeasureRepository)
        {
            _unitMeasureRepository = unitMeasureRepository;
        }

        public async Task<ErrorOr<IReadOnlyList<UnitMeasureResponse>>> Handle(GetAllUnitMeasureQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<UnitMeasure> UnitMeasures = await _unitMeasureRepository.GetAll();
            return UnitMeasures.Select(unitMeasure => new UnitMeasureResponse(
               unitMeasure.Id.Value,
               unitMeasure.Name,
               unitMeasure.Abbreviation,
               unitMeasure.Description
             )).ToList();
        }
    }
}
