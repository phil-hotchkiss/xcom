using Microsoft.Extensions.Caching.Memory;
using XCom.Domain.Models;
using XCom.Domain.Interfaces;

namespace XCom.Infrastructure.Repositories
{
    public class TemplateSetRepository : ITemplateSetRepository
    {
        private readonly IMemoryCache _cache;
        private const string CacheKeyPrefix = "TemplateSet_";

        public TemplateSetRepository(IMemoryCache cache)
        {
            _cache = cache;
        }

        public async Task AddAsync(TemplateSet templateSet)
        {
            var allTemplateSets = _cache.Get<List<TemplateSet>>(CacheKeyPrefix) ?? new List<TemplateSet>();
            allTemplateSets.Add(templateSet);
            _cache.Set(CacheKeyPrefix, allTemplateSets);
        }

        public async Task<List<TemplateSet>> GetByQueryAsync(string sendGridTemplateId, string templateSetName)
        {
            var allTemplateSets = _cache.Get<List<TemplateSet>>(CacheKeyPrefix) ?? new List<TemplateSet>();
            var query = allTemplateSets.AsQueryable();

            if (!string.IsNullOrEmpty(sendGridTemplateId))
            {
                query = query.Where(ts => ts.Variations.Any(v => v.SendGridTemplateId == sendGridTemplateId));
            }

            if (!string.IsNullOrEmpty(templateSetName))
            {
                query = query.Where(ts => ts.TemplateSetName.Contains(templateSetName, StringComparison.OrdinalIgnoreCase));
            }

            return await Task.FromResult(query.ToList());
        }

        public async Task<TemplateSet> GetByIdAsync(Guid id)
        {
            var allTemplateSets = _cache.Get<List<TemplateSet>>(CacheKeyPrefix) ?? new List<TemplateSet>();
            var templateSet = allTemplateSets.FirstOrDefault(ts => ts.Id == id);

            return await Task.FromResult(templateSet);
        }

        public async Task UpdateAsync(TemplateSet templateSet)
        {
            var allTemplateSets = _cache.Get<List<TemplateSet>>(CacheKeyPrefix) ?? new List<TemplateSet>();
            var existingIndex = allTemplateSets.FindIndex(ts => ts.Id == templateSet.Id);
            
            if (existingIndex != -1)
            {
                allTemplateSets[existingIndex] = templateSet;
                _cache.Set(CacheKeyPrefix, allTemplateSets);
            }
        }
    }
}
