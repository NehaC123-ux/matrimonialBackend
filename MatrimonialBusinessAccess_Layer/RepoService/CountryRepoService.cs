using AutoMapper;
using MatrimonialBusinessAccess_Layer.Interfaceservice;
using MatrimonialDataAccess_Layer.DatabaseContext;
using MatrimonialModel_Layer.DTO;
using MatrimonialModel_Layer.Model;
using Microsoft.EntityFrameworkCore;

namespace MatrimonialBusinessAccess_Layer.RepoService
{
    public class CountryRepoService : ICountryRepoService
    {
        private readonly AppDbConnection _connection;
        private readonly IMapper _mapper;
        public CountryRepoService(AppDbConnection connection, IMapper mapper)
        {
            this._connection = connection;
            this._mapper = mapper;
        }

        public async Task DeleteCountryDetails(Guid CountryId)
        {
            try
            {
                var result = await _connection.CountryMasters.FirstOrDefaultAsync(x => x.CountryId == CountryId);
                if (result == null)
                {
                    throw new Exception("It will be not deleted");
                }
                _connection.CountryMasters.Remove(result);
                await _connection.SaveChangesAsync();

            }
            catch
            (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public async Task<List<CountryDto>> GetAllCountryList()
        {
            try
            {
                var result = await _connection.CountryMasters.Include(x => x.StateMasters).ToListAsync();
                var map = _mapper.Map<List<CountryDto>>(result);
                return map;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CountryDto> GetCountryDetailsById(Guid CountryId)
        {
            try
            {
                var result=await _connection.CountryMasters.FirstOrDefaultAsync(x=>x.CountryId == CountryId);
                var map = _mapper.Map<CountryDto>(result);
                return map;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task NewCountryDetails(CountryDto country)
        {
            try
            {

                var map = _mapper.Map<CountryMaster>(country);
                await _connection.CountryMasters.AddAsync(map);
                if (country == null)
                {
                    throw new Exception("it Can not Add");
                }
                await _connection.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateDataCountry(CountryDto country)
        {
            try
            {
                var map = _mapper.Map<CountryMaster>(country);
                var result = await _connection.CountryMasters.FirstOrDefaultAsync(x => x.CountryId == country.CountryId);
                if (result == null)
                {
                    throw new Exception("It can not update");
                }
                result.CountryId = country.CountryId;
                result.CountryName = country.CountryName;
                result.Status = country.Status;
                result.CreatedOn = country.CreatedOn;
                result.CreatedBY = country.CreatedBY;
                result.ModifiedOn = country.ModifiedOn;
                result.ModifiedBy = country.ModifiedBy;
                _connection.CountryMasters.Update(result);
                await _connection.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
