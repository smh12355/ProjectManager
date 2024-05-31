using ProjectManager.Domain.Contracts.DocSet;

namespace ProjectManager.Application.Abstractions
{
    public interface IDocSetService
    {
        Task<List<DocSetByProjectResponce>> Get();
    }
}