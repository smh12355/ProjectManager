using ProjectManager.Domain.Models.Mark;

namespace ProjectManager.Domain.Models.DocSet;

public record DocSetResponse(int Id, int DesignObjectId, Mark.Mark Mark, int Number);
