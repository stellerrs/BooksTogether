namespace BooksTogether.Domain.ValueObjects;

public abstract class ValueObject : IEquatable<ValueObject>
{
    protected abstract IEnumerable<object> GetAtomicValues();
    
    public override int GetHashCode() =>
        GetAtomicValues().Aggregate(
            default(int),
            (hashcode, value) => HashCode.Combine(hashcode, value.GetHashCode()));
    
    private bool AreEquals(ValueObject other) =>
        other is not null && GetAtomicValues().SequenceEqual(other.GetAtomicValues());
    
    public virtual bool Equals(ValueObject? other) =>
        other is not null && AreEquals(other);
    
    public override bool Equals(object? obj) =>
        obj is ValueObject other && AreEquals(other);
    
    public static bool operator ==(ValueObject? left, ValueObject? right)
    {
        if (left is null && right is null) return true;
        if (left is null || right is null) return false;
        
        return Equals(left, right);
    }

    public static bool operator !=(ValueObject? left, ValueObject? right) =>
        !(left == right);
}