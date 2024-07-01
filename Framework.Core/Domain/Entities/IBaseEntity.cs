namespace Framework.Core.Domain.Entities;

public interface IBaseEntity
{
    public Guid Id { get; set; }
    public DateTime Created { get; set; }
    public Guid CreatedBy { get; set; }

    public DateTime LastEdited { get; set; }
    public Guid? LastEditedBy { get; set; }

    public bool IsRemove { get; set; }
    public DateTime Removed { get; set; }
    public Guid RemovedBy { get; set; }
}
}