
namespace ElmTest.Domain.Common;

public abstract class AggregateRoot : Entity
{
    protected AggregateRoot(Int64 id) : base(id)
    {
    }
    protected AggregateRoot() { }
}