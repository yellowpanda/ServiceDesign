namespace ApplicationLayer.Shared;

public record ValidationError(string error)
{
    public override string ToString()
    {
        return error;
    }
}