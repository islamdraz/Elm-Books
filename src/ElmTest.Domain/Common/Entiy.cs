namespace ElmTest.Domain.Common;

public abstract class Entity
{
    public Int64 Id { get; }

    protected Entity(Int64 id)
    {
        this.Id = id;
    }
    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType())
        {
            return false;
        }

        return ((Entity)obj).Id == Id;
    }

    public override int GetHashCode()
    {
        return this.Id.GetHashCode();
    }
    protected Entity() { }
}