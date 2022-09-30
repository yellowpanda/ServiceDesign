namespace ApplicationLayer;

public interface ISyntaxValidator<in TRequest> where TRequest : IRequest
{
    public ValidationResult Validate(TRequest request);
}