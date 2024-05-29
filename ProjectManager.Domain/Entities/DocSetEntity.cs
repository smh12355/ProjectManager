using ProjectManager.Domain.Models;

namespace ProjectManager.Domain.Entities;

public class DocSetEntity
{
    public int Id { get; set; }
    public int DesignObjectId { get; set; }
    public Mark Mark { get; set; }
    public int Number {  get; set; }

    //Nagiation to DesignObject
    public DesignObjectEntity DesignObject { get; set; }
}
