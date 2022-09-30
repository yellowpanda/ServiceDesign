namespace ApplicationLayer.Shared;

public class ValidationResult
{
    public IList<ValidationError> ValidationErrors { get; }

    public bool Success => !ValidationErrors.Any();


    public ValidationResult() : this(new List<ValidationError>())
    {
    }

    public ValidationResult(IEnumerable<ValidationError> validationErrors)
    {
        ValidationErrors = new List<ValidationError>(validationErrors);
    }

    public ValidationResult(ValidationError validationError) : this(new List<ValidationError>() { validationError })
    {
    }
}