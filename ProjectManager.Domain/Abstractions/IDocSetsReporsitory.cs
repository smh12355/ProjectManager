using ProjectManager.Domain.Models;

namespace ProjectManager.Domain.Abstractions;

public interface IDocSetsReporsitory
{
    Task<int> Create(DocSet docSet);
    Task<int> Delete(int id);
    Task<List<DocSet>> Get();
    Task<int> Update(int id, int designObjectId, Mark mark, int Number);
}