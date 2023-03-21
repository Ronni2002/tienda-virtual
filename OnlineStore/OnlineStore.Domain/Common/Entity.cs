namespace OnlineStore.Domain.Common;

public class Entity
{
    public Guid Id { get; set; }
    public DateTimeOffset Created { get; set; }
    public string CreateBy { get; set; } = null!;
    public DateTimeOffset? Updated { get; set; }
    public string? UpdateBy { get; set; }
    public bool IsDeleted { get; set; }
    public Guid DeleteToken { get; set; } = Guid.Empty;
}