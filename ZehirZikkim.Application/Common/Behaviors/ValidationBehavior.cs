using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace ZehirZikkim.Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest: IRequest<TResponse>
    where TResponse: IErrorOr
{

     private readonly IValidator<TRequest>? validator;

    public ValidationBehavior(IValidator<TRequest>? validator = null)
    {
        this.validator = validator;
    }



    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
       
        if(validator is null) return await next();
        if ( await 
                validator.ValidateAsync(request, cancellationToken) 
                is var validationResult && validationResult.IsValid) return await next();
        
        return (dynamic)validationResult
            .Errors
            .ConvertAll(e => 
                Error.Validation(code: e.PropertyName, description: e.ErrorMessage));
    }
}