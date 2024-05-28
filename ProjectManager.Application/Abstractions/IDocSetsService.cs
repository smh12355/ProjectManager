using ProjectManager.Domain.Models;

namespace ProjectManager.Domain.Abstractions;

public interface IDocSetsService
{
    Task<int> CreateDocSet(DocSet docSet);
    Task<int> DeleteDocSet(int id);
    Task<List<DocSet>> GetAllDocSets();
    Task<int> UpdateDocSet(int id, int designObjectId, Mark mark, int Number);
}