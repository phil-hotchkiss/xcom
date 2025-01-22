using System.Threading.Tasks;
using FluentResults;
using XCom.Domain.Models;

namespace XCom.Domain.Interfaces
{
    public interface IEmailService
    {
        Task<Result> SendEmailAsync(Email email);
        Task<Result> SendTemplatedEmailAsync(Email email, string templateId);
    }
}
