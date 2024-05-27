using ProjectManager.Domain.Abstractions;
using ProjectManager.Domain.Models;
using ProjectManager.Infrastructure.Repository;

namespace ProjectManager.Application.Services;

public class DocSetsService : IDocSetsService
{
    private readonly IDocSetsReporsitory _docSetsRepository;

    public DocSetsService(IDocSetsReporsitory docSetsReporsitory)
    {
        _docSetsRepository = docSetsReporsitory;
    }

    public async Task<List<DocSet>> GetAllDocSets()
    {
        return await _docSetsRepository.Get();
    }

    public async Task<int> CreateDocSet(DocSet docSet)
    {
        return await _docSetsRepository.Create(docSet);
    }

    public async Task<int> UpdateDocSet(int id, int designObjectId, Mark mark, int Number)
    {
        return await _docSetsRepository.Update(id, designObjectId, mark, Number);
    }

    public async Task<int> DeleteDocSet(int id)
    {
        return await _docSetsRepository.Delete(id);
    }
}
