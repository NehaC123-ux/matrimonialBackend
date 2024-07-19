using AutoMapper;
using MatrimonialBusinessAccess_Layer.Interfaceservice;
using MatrimonialDataAccess_Layer.DatabaseContext;
using MatrimonialModel_Layer.DTO;
using MatrimonialModel_Layer.Model;
using Microsoft.EntityFrameworkCore;

namespace MatrimonialBusinessAccess_Layer.RepoService
{
    public class StateRepoService : IStateRepoService
    {
        private readonly AppDbConnection _connection;
        private readonly IMapper _mapper;
        public StateRepoService(AppDbConnection connection, IMapper mapper)
        {
            this._connection = connection;
            this._mapper = mapper;
        }

        public async Task AddNewState(StateDto state)
        {
            try
            {
                var map = _mapper.Map<StateMaster>(state);
                await _connection.StateMasters.AddAsync(map);
                if (map == null)
                {
                    throw new Exception("Con not be Add");
                }
                await _connection.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteNewState(Guid StateId)
        {
            try
            {
                var result = await _connection.StateMasters.FirstOrDefaultAsync(x => x.StateId == StateId);
                if (result == null)
                {
                    throw new Exception("Delete Successfully");
                }
                _connection.StateMasters.Remove(result);
                await _connection.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<StateDto>> GetAllStateList()
        {
            try
            {
                var result = await _connection.StateMasters.Include(x => x.DistrictMasters).ToListAsync();
                var map = _mapper.Map<List<StateDto>>(result);
                return map;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<StateDto>> GetCountryById(Guid countryId)
        {
            try
            {
                var result =  _connection.StateMasters.Where(x => x.CountryId == countryId);
                return _mapper.Map<List<StateDto>>(result);

            }
            catch (Exception ex)
            {    
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateNewState(StateDto state)
        {
            try
            {
                var map = _mapper.Map<StateMaster>(state);
                var result = await _connection.StateMasters.FirstOrDefaultAsync(x => x.StateId == state.StateId);
                if (result == null)
                {
                    throw new Exception("update data successfully");
                }
                result.StateId = state.StateId;
                result.StateName = state.StateName;
                result.Status = state.Status;
                result.CreatedBY = state.CreatedBY;
                result.CreatedOn = state.CreatedOn;
                result.ModifiedBy = state.ModifiedBy;
                result.ModifiedOn = state.ModifiedOn;
                _connection.StateMasters.Update(result);
                await _connection.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
