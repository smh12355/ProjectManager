namespace ProjectManager.Domain.Entities;

public class ProjectEntity
{
    public int Id { get; set; }
    public string Cipher { get; set; }
    public string Name { get; set; }

    //Navigation
    public ICollection<DesignObjectEntity> DesignObjects { get; set; }
}
