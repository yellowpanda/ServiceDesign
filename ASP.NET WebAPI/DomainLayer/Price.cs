using ValueOf;

namespace DomainLayer;

public class Price : ValueOf<decimal, Price>
{
    protected override void Validate()
    {
        if (!TryValidate())
        {
            throw new ArgumentException("Price cannot be less than zero.");
        }
    }

    protected override bool TryValidate()
    {
        return Value >= 0;
    }
}