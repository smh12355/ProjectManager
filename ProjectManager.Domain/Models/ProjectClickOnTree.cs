using ProjectManager.Domain.Entities;

namespace ProjectManager.Domain.Models;

//public record ProjectClickOnTree(string Cipher, string DesignObjectHierarchyCode, int Mark, int DocSetNumberWithMark, int SumOfShipres);
//public record SimpleOne(int projectId, string designObjectChiefre, string projectName,
//    int designObjectId, int ParentDesignObjectId, string designObjectCode, string designObjectName,
//    int docSetId, int docSetMark, int docSetNumber);
public record ProjectDetailsDto(
    int ProjectId,
    string ProjectName,
    string ProjectCipher,
    List<DesignObjectDetailsDto> DesignObjects
);

public record DesignObjectDetailsDto(
    int DesignObjectId,
    string DesignObjectName,
    string DesignObjectCode,
    List<DocSetDetailsDto> DocSets
);

public record DocSetDetailsDto(
    int DocSetId,
    Mark DocSetMark,
    int DocSetNumber
);

