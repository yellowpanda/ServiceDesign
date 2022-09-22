namespace ApplicationLayer;

public interface ISyntaxValidator<in TRequest> where TRequest : IRequest
{
    public SyntaxValidationResult Validate(TRequest request);
}