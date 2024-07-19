using AutoMapper;
using MatrimonialBusinessAccess_Layer.Interfaceservice;
using MatrimonialDataAccess_Layer.DatabaseContext;
using MatrimonialModel_Layer.DTO;
using MatrimonialModel_Layer.Model;
using Microsoft.EntityFrameworkCore;

namespace MatrimonialBusinessAccess_Layer.RepoService
{
    public class DistrictRepoService : IDistrictRepoService
    {
        private readonly AppDbConnection _connection;
        private readonly IMapper _mapper;
        public DistrictRepoService(AppDbConnection connection, IMapper mapper)
        {
            this._connection = connection;
            this._mapper = mapper;
        }

        public async Task AddNewDistrict(DistrictDto district)
        {
            try
            {
                var map = _mapper.Map<DistrictMaster>(district);
                await _connection.DistrictMasters.AddAsync(map);
                if (map == null)
                {
                    throw new Exception("Can not Found");
                }
                await _connection.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteDistrict(Guid districtId)
        {
            try
            {
                var result = await _connection.DistrictMasters.FirstOrDefaultAsync(x => x.DistrictId == districtId);
                if (result == null)
                {
                    throw new Exception("Can not be Delete");
                }
                _connection.DistrictMasters.Remove(result);
                await _connection.SaveChangesAsync();

            }
            catch
            (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<DistrictDto>> GetDistrictById(Guid stateid)
        {
            try
            {
                var result =  _connection.DistrictMasters.Where(x => x.StateId == stateid);
                return _mapper.Map<List<DistrictDto>>(result);
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<DistrictDto>> GetDistrictsList()
        {
            try
            {
                var result = await _connection.DistrictMasters.ToListAsync();
                var map = _mapper.Map<List<DistrictDto>>(result);
                return map;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateDataDistrict(DistrictDto district)
        {
            try
            {
                var map = _mapper.Map<DistrictMaster>(district);
                var result = await _connection.DistrictMasters.FirstOrDefaultAsync(x => x.DistrictId == district.DistrictId);
                if (result == null)
                {
                    throw new Exception("It wil be not update");
                }
                result.DistrictId = district.DistrictId;
                result.DistrictName = district.DistrictName;
                result.Status = district.Status;
                result.CreatedBY = district.CreatedBY;
                result.CreatedOn = district.CreatedOn;
                result.ModifiedBy = district.ModifiedBy;
                result.ModifiedOn = district.ModifiedOn;
                result.StateId = district.StateId;
                _connection.DistrictMasters.Update(result);
                await _connection.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
