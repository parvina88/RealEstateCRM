namespace RealEstate.Application.Behaviors;

public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        ErrorResponse errorResponse = await ValidateAllAsync(request, cancellationToken);
        if (errorResponse.Errors.Count > 0)
        {
            throw new ValidationFailedException(errorResponse);
        }
        return await next();
    }

    private async Task<ErrorResponse> ValidateAllAsync(TRequest request, CancellationToken cancellationToken)
    {
        ErrorResponse errorResponse = new ErrorResponse
        {
            Errors = new List<ErrorMessage>()
        };

        foreach (var validator in _validators)
        {
            var result = await validator.ValidateAsync(request, cancellationToken);
            if (!result.IsValid)
            {
                errorResponse.Errors.AddRange(result.Errors.Select(errors => new ErrorMessage
                {
                    PropertyName = errors.PropertyName,
                    Message = errors.ErrorMessage
                }));
            }
        }

        return errorResponse;
    }
}
