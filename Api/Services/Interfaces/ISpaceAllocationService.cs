using Api.Models.Responses;
using System;
using System.Threading.Tasks;

namespace Api.Services.Interfaces
{
    public interface ISpaceAllocationService
    {
        Task<AllocatedSpaceResponse> GetSpaceAllocationForUser(Guid userId);        
    }
}
