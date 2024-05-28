namespace ProjectManager.Domain.Models;

public record TreeData(int Id, string ProjectName, List<DesignObjectsPerProject> DesignObjectsNames);
public record DesignObjectsPerProject(int Id, string Name);
public record TreeDataAnother(int ProjectId, string ProjectName, int DesignObjectID, string DesignObjectName);