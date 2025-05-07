namespace Vulcano.Domain.ValueObjects;

public class SerialNumber
{
    public string Value { get; }

    public SerialNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
            throw new ArgumentException("Serial number inválido.");

        Value = value.ToUpperInvariant();
    }

    public override string ToString() => Value;

    public override bool Equals(object? obj) =>
        obj is SerialNumber sn && Value == sn.Value;

    public override int GetHashCode() => Value.GetHashCode();
}
