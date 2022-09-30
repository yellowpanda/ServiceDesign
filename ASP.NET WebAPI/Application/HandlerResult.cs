namespace ApplicationLayer;

public class HandlerResult<TResponse>
{
    private readonly TResponse? _response;

    /// <summary>
    /// Did the input completed validation successful?
    /// </summary>
    public bool ValidationSuccessful { get; }

    /// <summary>
    /// The response from the handler. Is null if validation failed.
    /// </summary>
    public TResponse Response
    {
        get
        {
            if (!ValidationSuccessful)
            {
                throw new InvalidOperationException($"{nameof(Response)} is not suppose to be called when validation has failed. Please check {nameof(ValidationSuccessful)} property before accessing this property.");
            }
            return (TResponse)_response!;
        }
    }

    /// <summary>
    /// All validation errors.
    /// </summary>
    public ValidationResult ValidationResult { get; }

    /// <summary>
    /// Validation completed successful and a response is created. 
    /// </summary>
    public HandlerResult(TResponse response)
    {
        ValidationSuccessful = true;
        _response = response;
        ValidationResult = new ValidationResult();
    }

    /// <summary>
    /// Validation failed. No response created. 
    /// </summary>
    public HandlerResult(IEnumerable<ValidationError> validationErrors)
    {
        ValidationSuccessful = false;
        ValidationResult = new ValidationResult(validationErrors);
    }

    /// <summary>
    /// Validation failed. No response created.
    /// </summary>
    public HandlerResult(ValidationError validationError)
    {
        ValidationSuccessful = false;
        ValidationResult = new ValidationResult(validationError);
    }
}