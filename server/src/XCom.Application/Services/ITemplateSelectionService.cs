using XCom.Domain.Models;

namespace XCom.Application.Services
{
    public interface ITemplateSelectionService
    {
        Variation SelectTemplate(List<Variation> variations);
    }
}
