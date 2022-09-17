using Api.Models.Requests;
using Api.Models.Responses;
using System.Threading.Tasks;

namespace Api.Services.Interfaces
{
    public interface IOfficeService
    {
        Task<InsertOfficeResponse> CreateOfficePremise(InsertOfficeRequest insertOfficeRequest);
    }
}
