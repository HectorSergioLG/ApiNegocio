using Aplication.Identity.Catalogos.Products.UnitsMeasures.Common;
using Domain.Entities.Catalogs.Products.UnitsMesures;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Catalogos.Products.UnitsMeasures.GetById
{
    public class GetUnitMeasureByIdQueryHandler : IRequestHandler<GetUnitMeasureByIdQuery, ErrorOr<UnitMeasureResponse>>
    {
        private readonly IUnitMeasureRepository _unitMeasureRepository;
        public GetUnitMeasureByIdQueryHandler(IUnitMeasureRepository unitMeasureRepository)
        {
            _unitMeasureRepository = unitMeasureRepository ?? throw new ArgumentNullException(nameof(unitMeasureRepository));
        }
        public async Task<ErrorOr<UnitMeasureResponse>> Handle(GetUnitMeasureByIdQuery query, CancellationToken cancellationToken)
        {
            if (await _unitMeasureRepository.GetById(new UnitMeasureId(query.Id)) is not UnitMeasure unitMeasure)
            {
                return Error.NotFound("UnitMeasure.NoFound", "La unidad de medida no fue encontrada.");
            }
            return new UnitMeasureResponse(
               unitMeasure.Id.Value,
               unitMeasure.Name,
               unitMeasure.Abbreviation,
               unitMeasure.Description
             );
        }
    }
}
