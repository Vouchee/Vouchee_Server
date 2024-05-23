using Vouchee.Domain.WebRequests.Foo;

namespace Vouchee.Infrastructure.Services.Foo;

public sealed class FooService : IFooService
{
    public Task CreateFooAsync(CreateFooRequest request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
