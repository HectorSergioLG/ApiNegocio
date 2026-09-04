using FluentValidation;

namespace Aplication.Identity.Catalogos.Customers.Delete
{
    public  class DeleteCustomerCommandValidator:AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
