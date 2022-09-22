namespace ApplicationLayer
{
    public class ValidationResult
    {
        public List<string> Errors { get; } = new();

        public bool Success => !Errors.Any();
    }
}
