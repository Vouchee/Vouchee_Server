namespace Vouchee.Domain.Common;

public class BaseEntity<T> where T : notnull
{
    public required T Id { get; set; }
}
