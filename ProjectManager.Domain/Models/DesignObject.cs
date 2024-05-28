namespace ProjectManager.Domain.Models;

public record DesignObject(int Id, int? ParentDesignObjectId, string Code, string Name);

public record DesigObjectPerLayer(int Id, int? ParentDesignObjectId, string Code, string Name,
    List<DesigObjectPerLayer> childrenObjects);