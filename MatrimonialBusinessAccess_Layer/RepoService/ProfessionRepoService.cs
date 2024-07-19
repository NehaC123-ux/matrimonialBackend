using AutoMapper;
using MatrimonialBusinessAccess_Layer.Interfaceservice;
using MatrimonialDataAccess_Layer.DatabaseContext;
using MatrimonialModel_Layer.DTO;
using MatrimonialModel_Layer.Model;
using Microsoft.EntityFrameworkCore;

namespace MatrimonialBusinessAccess_Layer.RepoService
{
    public class ProfessionRepoService : IProfessionRepoService
    {
        private readonly AppDbConnection _connection;
        private readonly IMapper _mapper;
        public ProfessionRepoService(AppDbConnection connection, IMapper mapper)
        {
            this._connection = connection;
            this._mapper = mapper;
        }

        public async Task addProfessionDetails(ProfessionDto profession)
        {
            try
            {
                var map = _mapper.Map<ProfessionMaster>(profession);
                await _connection.professionMasters.AddAsync(map);
                if (map == null)
                {
                    throw new Exception("Can not new profession add");
                }
                await _connection.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task deleteProfessionDetails(Guid professionId)
        {
            try
            {
                var result = await _connection.professionMasters.FirstOrDefaultAsync(x => x.ProfessionId == professionId);
                if (result == null)
                {
                    throw new Exception("It will be not delete");
                }
                _connection.professionMasters.Remove(result);
                await _connection.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ProfessionDto>> getProfessionList()
        {
            try
            {
                var result = await _connection.professionMasters.ToListAsync();
                var map = _mapper.Map<List<ProfessionDto>>(result);
                return map;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task updateProfessionDetails(ProfessionDto profession)
        {
            try
            {

                var map = _mapper.Map<ProfessionMaster>(profession);
                var result = await _connection.professionMasters.FirstOrDefaultAsync(x => x.ProfessionId == profession.ProfessionId);
                if (result == null)
                {
                    throw new Exception("Can not update");

                }
                result.ProfessionId = result.ProfessionId;
                result.ProfessionName = result.ProfessionName;
                result.Status = result.Status;
                result.CreatedBY = result.CreatedBY;
                result.CreatedOn = result.CreatedOn;
                result.ModifiedOn = result.ModifiedOn;
                result.ModifiedBy = result.ModifiedBy;
                _connection.professionMasters.Update(result);
                await _connection.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
