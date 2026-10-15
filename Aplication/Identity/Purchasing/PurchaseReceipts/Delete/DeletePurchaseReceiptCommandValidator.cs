using FluentValidation;

namespace Aplication.Identity.Purchasing.PurchaseReceipts.Delete
{
    public sealed class DeletePurchaseReceiptCommandValidator : AbstractValidator<DeletePurchaseReceiptCommand>
    {
        public DeletePurchaseReceiptCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("El identificador de la recepción es requerido.");
        }
    }
}
