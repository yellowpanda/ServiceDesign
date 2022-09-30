namespace ApplicationLayer;

public record ValidationError(string error)
{
    public override string ToString()
    {
        return error;
    }
}