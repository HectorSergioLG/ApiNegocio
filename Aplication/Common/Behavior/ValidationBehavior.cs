using ErrorOr;
using MediatR;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Common.Behavior
{
    /// <summary>
    /// Clase para validar los parametros del comando CreateCommand
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse> where TResponse : IErrorOr
    {
        private readonly IValidator<TRequest> _validator;
        /// <summary>
        /// Constructor de la clase ValidationBehavior
        /// </summary>
        /// <param name="validator"></param>
        public ValidationBehavior(IValidator<TRequest> validator)
        {
            _validator = validator;
        }

        /// <summary>
        /// Manejador del comando ValidationBehavior, este se encarga de validar los parametros del comando CreateCommand
        /// </summary>
        /// <param name="request"></param>
        /// <param name="next"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {

            if (_validator is null)
            {
                return await next();
            }

            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            
            if (validationResult.IsValid)
            {
                return await next();
            }

            var errors = validationResult.Errors.ConvertAll(validationFailure => Error.Validation(
                validationFailure.PropertyName,
                validationFailure.ErrorMessage));

            return (dynamic) errors;
        }
    }
}
