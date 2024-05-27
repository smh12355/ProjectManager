namespace ProjectManager.Infrastructure.Entities;

public class DocSetEntity
{
    public int Id { get; set; }
    public int DesignObjectId { get; set; }
    public MarkEntity Mark { get; set; }
    public int Number {  get; set; }

    //Nagiation to DesignObject
    public DesignObjectEntity DesignObject { get; set; }
}
