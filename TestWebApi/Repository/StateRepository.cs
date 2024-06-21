using Microsoft.EntityFrameworkCore;
using TestWebApi.Data;

using TestWebApi.Dtos.StateAndCapital;
using TestWebApi.Interface;
using TestWebApi.Models;

namespace TestWebApi.Repository
{
    public class StateRepository : IStateCapitalRepository
    {
        private readonly ApplicationDbContext _context;
        public StateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

   
        public async Task<StateAndCapital> CreateAsync(StateAndCapital stateModel)
        {
            await _context.StateAndCapitals.AddAsync(stateModel);
            await _context.SaveChangesAsync();
            return stateModel;
        }

        public async Task<StateAndCapital?> DeleteAsync(Guid id)
        {
            var stateModel = await _context.StateAndCapitals.FirstOrDefaultAsync(x => x.Id == id);
            if (stateModel == null)
            {
                return null;
            }

            _context.StateAndCapitals.Remove(stateModel);
            await _context.SaveChangesAsync();
            return stateModel;
        }

        public Task<List<StateAndCapitalDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<StateAndCapital?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
