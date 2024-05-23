namespace Vouchee.Domain.WebRequests.Foo;

public record CreateFooRequest
{
    public required string Name { get; set; }
}
