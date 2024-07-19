using AutoMapper;
using MatrimonialBusinessAccess_Layer.Interfaceservice;
using MatrimonialDataAccess_Layer.DatabaseContext;
using MatrimonialModel_Layer.DTO;
using MatrimonialModel_Layer.Model;
using Microsoft.EntityFrameworkCore;

namespace MatrimonialBusinessAccess_Layer.RepoService
{
    public class GotraRepoService : IGotraRepoService
    {
        private readonly AppDbConnection _connection;
        private readonly IMapper _mapper;
        public GotraRepoService(AppDbConnection connection, IMapper mapper)
        {
            this._connection = connection;
            this._mapper = mapper;
        }

        public async Task AddGotraData(GotraDto gotra)
        {
            try
            {
                var map = _mapper.Map<GotraMaster>(gotra);
                await _connection.gotraMasters.AddAsync(map);
                if (map == null)
                {
                    throw new Exception("Can not add");
                }
                await _connection.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteDataGotra(Guid gotraId)
        {
            try
            {
                var result = await _connection.gotraMasters.FirstOrDefaultAsync(x => x.GotraId == gotraId);
                if (result == null)
                {
                    throw new Exception("It will be not Delete");
                }
                _connection.gotraMasters.Remove(result);
                await _connection.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<GotraDto>> GetgotraById(Guid subcasteId)
        {
            try
            {
                var result = _connection.gotraMasters.Where(x => x.SubCasteId == subcasteId);
                return _mapper.Map<List<GotraDto>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<GotraDto>> GetGotraList()
        {
            try
            {
                var result = await _connection.gotraMasters.ToListAsync();
                var map = _mapper.Map<List<GotraDto>>(result);
                return map;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateGotraDetails(GotraDto gotra)
        {
            try
            {
                var map = _mapper.Map<GotraMaster>(gotra);
                var result = await _connection.gotraMasters.FirstOrDefaultAsync(x => x.GotraId == gotra.GotraId);
                if (result == null)
                {
                    throw new Exception("Update Can not ");
                }
                result.GotraId = gotra.GotraId;
                result.GotraName = gotra.GotraName;
                result.Status = gotra.Status;
                result.ModifiedBy = gotra.ModifiedBy;
                result.ModifiedOn = gotra.ModifiedOn;
                result.CreatedBY = gotra.CreatedBY;
                result.CreatedOn = gotra.CreatedOn;
                _connection.gotraMasters.Update(result);
                await _connection.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
