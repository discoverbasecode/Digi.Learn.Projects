namespace Framework.Core.Domain.Entities;

public class BaseEntity : IBaseEntity
{
    public Guid Id { get; set; } = new Guid();

    public DateTime Created { get; set; } = DateTime.Now;
    public Guid CreatedBy { get; set; }

    public DateTime LastEdited { get; set; }
    public Guid? LastEditedBy { get; set; }

    public bool IsRemove { get; set; } = false;
    public DateTime Removed { get; set; }
    public Guid RemovedBy { get; set; }
}