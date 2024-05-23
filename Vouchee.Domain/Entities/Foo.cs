using Vouchee.Domain.Common;

namespace Vouchee.Domain.Entities;

public class Foo : BaseEntity<Guid>
{
    public required string Name { get; set; }
}
