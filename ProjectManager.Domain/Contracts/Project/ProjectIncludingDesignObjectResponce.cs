using ProjectManager.Domain.Contracts.DesignObject;

namespace ProjectManager.Domain.Contracts.Project;

public record ProjectIncludingDesignObjectResponce(int Id,
                                                   string Name,
                                                   string Cipher,
                                                   List<DesignObjectResponce> DesignObjects);
