using Vouchee.Domain.WebRequests.Foo;

namespace Vouchee.Infrastructure.Services.Foo;

public interface IFooService
{
    Task CreateFooAsync(CreateFooRequest request, CancellationToken cancellationToken = default);
}
