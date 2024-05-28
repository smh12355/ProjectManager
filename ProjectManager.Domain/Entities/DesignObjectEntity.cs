using ProjectManager.Domain.Models;

namespace ProjectManager.Infrastructure.Entities;

public class DesignObjectEntity
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public int? ParentDesignObjectId { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }

    //Navigation to Project
    public ProjectEntity Project { get; set; }
    //Navigation to DesignProjectParent
    public DesignObjectEntity ParentDesignObject { get; set; }
    public ICollection<DesignObjectEntity> ChildrenDesignObjects { get; set; }
    //Navigation to DocSet
    public ICollection<DocSetEntity> DocSets { get; set; }
}
