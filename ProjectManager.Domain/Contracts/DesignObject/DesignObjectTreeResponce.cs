
namespace ProjectManager.Domain.Contracts.DesignObject;

public record DesignObjectTreeResponce(int Id,
                                       int? ParentId,
                                       string? Ciphre,
                                       List<DesignObjectTreeResponce> Childs);