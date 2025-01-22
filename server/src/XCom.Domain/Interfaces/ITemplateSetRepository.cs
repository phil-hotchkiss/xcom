using XCom.Domain.Models;

namespace XCom.Domain.Interfaces
{
    public interface ITemplateSetRepository
    {
        Task<TemplateSet> GetByIdAsync(Guid id);
        Task<List<TemplateSet>> GetByQueryAsync(string sendGridTemplateId, string templateSetName);
        Task AddAsync(TemplateSet templateSet);
        Task UpdateAsync(TemplateSet templateSet);
    }
}
