 using AutoMapper;
using MatrimonialBusinessAccess_Layer.Interfaceservice;
using MatrimonialDataAccess_Layer.DatabaseContext;
using MatrimonialModel_Layer.DTO;
using MatrimonialModel_Layer.Model;
using Microsoft.EntityFrameworkCore;

namespace MatrimonialBusinessAccess_Layer.RepoService
{
    public class SubCasteRepoService : ISubCasteRepoService
    {
        private readonly AppDbConnection _connection;
        private readonly IMapper _mapper;
        public SubCasteRepoService(AppDbConnection connection, IMapper mapper)
        {
            this._connection = connection;
            this._mapper = mapper;
        }

        public async Task AddDataSubCaste(SubCasteDto subCaste)
        {
            try
            {
                var mapp = _mapper.Map<SubCasteMaster>(subCaste);
                await _connection.subCasteMasters.AddAsync(mapp);
                await _connection.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteDataSubCaste(Guid subCasteId)
        {
            try
            {
                var result = await _connection.subCasteMasters.FirstOrDefaultAsync(x => x.SubCasteId == subCasteId);
                if (result == null)
                {
                    throw new Exception("It has not Deleted");
                }
                _connection.subCasteMasters.Remove(result);
                await _connection.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<SubCasteDto>> GetSubCasteList()
        {
            try
            {
                var result = await _connection.subCasteMasters.Include(a => a.GotraMasters).ToListAsync();
                var map = _mapper.Map<List<SubCasteDto>>(result);
                return map;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateDataSubCaste(SubCasteDto dataSubCaste)
        {
            try
            {
                var map = _mapper.Map<SubCasteMaster>(dataSubCaste);
                var result = await _connection.subCasteMasters.FirstOrDefaultAsync(x => x.SubCasteId == dataSubCaste.SubCasteId);
                if (result == null)
                {
                    throw new Exception("UpdateData Not Successfully");
                }
                result.SubCasteId = dataSubCaste.SubCasteId;
                result.SubCasteName = dataSubCaste.SubCasteName;
                result.Status = dataSubCaste.Status;
                result.CreatedBY = dataSubCaste.CreatedBY;
                result.CreatedOn = dataSubCaste.CreatedOn;
                result.ModifiedBy = dataSubCaste.ModifiedBy;
                result.ModifiedOn = dataSubCaste.ModifiedOn;
                _connection.subCasteMasters.Update(result);
                await _connection.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
