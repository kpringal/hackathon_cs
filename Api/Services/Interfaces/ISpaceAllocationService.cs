using Api.Models.Requests;
using Api.Models.Responses;
using System;
using System.Threading.Tasks;

namespace Api.Services.Interfaces
{
    public interface ISpaceAllocationService
    {
        Task<AllocatedSpaceResponse> GetSpaceAllocationForUser(GetAllocatedSpaceRequest request);
        Task<AllocationResponse> AllocateSpace(AllocateSpaceRequest request);
        Task<AllocationResponse> AllocateSeats(AllocateSeatRequest request);
    }
}
