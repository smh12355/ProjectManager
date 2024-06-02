using ProjectManager.Domain.Entities;

namespace ProjectManager.Domain.Contracts.Project;

public record ProjectIncludeAllObjects(int ProjectId,
                                       string? ProjectCipher,
                                       string? ProjectName,
                                       int DesignObjectId,
                                       string? DesignObjectCode,
                                       string? DesignObjectName,
                                       int DocSetId,
                                       string Mark,
                                       string MarkFullName,
                                       int DocSetNumber);
