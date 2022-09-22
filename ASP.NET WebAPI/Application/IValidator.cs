namespace ApplicationLayer;

public interface IValidator<in TRequest> where TRequest : IRequest
{
    public ValidationResult Validate(TRequest request);
}