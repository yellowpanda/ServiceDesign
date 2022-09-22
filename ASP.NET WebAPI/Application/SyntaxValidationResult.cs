namespace ApplicationLayer
{
    public class SyntaxValidationResult
    {
        public List<string> Errors { get; } = new();

        public bool Success => !Errors.Any();
    }
}
