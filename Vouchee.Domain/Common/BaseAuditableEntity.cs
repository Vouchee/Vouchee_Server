namespace Vouchee.Domain.Common;

public class BaseAuditableEntity<T> : BaseEntity<T> where T : notnull
{
    public DateTime Created { get; set; }
    public required string CreatedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public string? LastModifiedBy { get; set; }
}
