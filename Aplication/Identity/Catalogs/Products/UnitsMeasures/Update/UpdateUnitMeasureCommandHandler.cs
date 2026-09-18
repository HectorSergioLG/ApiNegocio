using Domain.Entities.Catalogs.Products.UnitsMesures;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Catalogos.Products.UnitsMeasures.Update
{
    internal sealed class UpdateUnitMeasureCommandHandler : IRequestHandler<UpdateUnitMeasureCommand, ErrorOr<Unit>>
    {
        private readonly IUnitMeasureRepository _unitMeasureRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateUnitMeasureCommandHandler(IUnitMeasureRepository unitMeasureRepository, IUnitOfWork unitOfWork)
        {
            _unitMeasureRepository = unitMeasureRepository ?? throw new ArgumentNullException(nameof(unitMeasureRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<ErrorOr<Unit>> Handle(UpdateUnitMeasureCommand command, CancellationToken cancellationToken)
        {
            if (!await _unitMeasureRepository.Exists(new UnitMeasureId(command.Id)))
            {
                return Error.NotFound("UnidadMedida.NoFound", "La unidad de medida no fue encontrada.");
            }
            UnitMeasure unitMeasure = UnitMeasure.UpdateUnitMeasure(
                command.Id,
                command.Name,
                command.Abbreviation,
                command.Description
            );
            _unitMeasureRepository.Update(unitMeasure);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
