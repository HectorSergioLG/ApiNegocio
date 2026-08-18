using FluentValidation;

namespace Aplication.CustomersAplication.Delete
{
    public  class DeleteCustomerCommandValidator:AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
