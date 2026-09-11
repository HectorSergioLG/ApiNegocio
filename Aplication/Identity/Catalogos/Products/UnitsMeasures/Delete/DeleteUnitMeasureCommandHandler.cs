using Domain.Entities.Catalogs.Products.UnitsMesures;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Catalogos.Products.UnitsMeasures.Delete
{
    public sealed class DeleteUnitMeasureCommandHandler : IRequestHandler<DeleteUnitMeasureCommand, ErrorOr<Unit>>
    {
        private readonly IUnitMeasureRepository _unitMeasureRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUnitMeasureCommandHandler(IUnitMeasureRepository unitMeasureRepository, IUnitOfWork unitOfWork)
        {
            _unitMeasureRepository = unitMeasureRepository;
            _unitOfWork = unitOfWork;
        }

        public async  Task<ErrorOr<Unit>> Handle(DeleteUnitMeasureCommand request, CancellationToken cancellationToken)
        {
            if (await _unitMeasureRepository.GetById(new UnitMeasureId(request.Id)) is not UnitMeasure unitMeasure) { 
                return Error.NotFound("UnitMeasure.NotFound","La unidad de medida no fue encontrada.");
            }

            _unitMeasureRepository.Delete(unitMeasure);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;

        }
    }
}
