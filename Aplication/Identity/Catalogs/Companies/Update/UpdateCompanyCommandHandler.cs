using Domain.Entities.Catalogs.Companies;
using Domain.Primitives;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Catalogs.Companies.Update;

public sealed class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, ErrorOr<Unit>>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCompanyCommandHandler(ICompanyRepository companyRepository, IUnitOfWork unitOfWork)
    {
        _companyRepository = companyRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        //var company = await _companyRepository.GetById(new CompanyId(request.Id));
        if (!await _companyRepository.Exists(new CompanyId(request.Id)))
        {
            return Error.NotFound("Company.NotFound", $"La empresa con Id '{request.Id}' no fue encontrada.");
        }

        if (PhoneNumber.Create(request.PhoneNumber) is not { } phoneNumber)
        {
            return Error.Validation("PhoneNumber.Invalid", "El número telefónico es inválido.");
        }

        if (Email.Create(request.Email) is not { } email)
        {
            return Error.Validation("Email.Invalid", "El correo electrónico es inválido.");
        }
        //Company Update(Guid id, string name, bool isActive, string tradeName, Email email, PhoneNumber phoneNumber)

        Company company = Company.Update(
            request.Id,
            request.Name,
            request.IsActive,
            request.TradeName,
            email,
            phoneNumber
        );


        _companyRepository.Update(company);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}