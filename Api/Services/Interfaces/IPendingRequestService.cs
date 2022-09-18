using Api.Models.Requests;
using Api.Models.Responses;
using System.Threading.Tasks;

namespace Api.Services.Interfaces
{
    public interface IPendingRequestService
    {
        Task<GetPendingSpaceResponse> GetPendingSpaceRequest(GetPendingSpaceRequest getPendingSpaceRequest);
    }
}
