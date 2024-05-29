namespace ProjectManager.Domain.Contracts.DesignObject;

public record DesignObjectResponce(int Id,
                                   int? ParentId,
                                   string Code,
                                   string Name);
