
using TestWebApi.Dtos.StateAndCapital;
using TestWebApi.Models;

namespace TestWebApi.Interface
{
    public interface IStateCapitalRepository
    {

        Task<List<StateAndCapitalDto>> GetAllAsync();
        Task<StateAndCapital?> GetByIdAsync(Guid id); 
        Task<StateAndCapital> CreateAsync(StateAndCapital stateModel);
     
        Task<StateAndCapital?> DeleteAsync(Guid id);
    }
}
