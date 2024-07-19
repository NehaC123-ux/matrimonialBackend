using AutoMapper;
using MatrimonialBusinessAccess_Layer.Interfaceservice;
using MatrimonialDataAccess_Layer.DatabaseContext;
using MatrimonialModel_Layer.DTO;
using MatrimonialModel_Layer.Model;
using Microsoft.EntityFrameworkCore;

namespace MatrimonialBusinessAccess_Layer.RepoService
{
    public class QualificationRepoService : IQualificationRepoService
    {
        private readonly AppDbConnection _connection;
        private readonly IMapper _mapper;
        public QualificationRepoService(AppDbConnection connection, IMapper mapper)
        {
            this._connection = connection;
            this._mapper = mapper;
        }

        public async Task DeleteQualificationData(Guid QualificationId)
        {
            try
            {
                var result = await _connection.qualificationMasters.FirstOrDefaultAsync(x => x.QualificationId == QualificationId);
                if (result == null)
                {
                    throw new Exception("Deleted not Successfully");
                }
                _connection.qualificationMasters.Remove(result);
                await _connection.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<QualificationDto>> GetAllQualifications()
        {
            try
            {
                var result = await _connection.qualificationMasters.ToListAsync();
                var map = _mapper.Map<List<QualificationDto>>(result);
                return map;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task NewQualificationData(QualificationDto Qualification)
        {
            try
            {
                var map = _mapper.Map<QualificationMaster>(Qualification);
                await _connection.qualificationMasters.AddAsync(map);
                if (map == null)
                {
                    throw new Exception("Not Posted");
                }
                await _connection.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateDataQualification(QualificationDto Qualification)
        {
            try
            {
                var map = _mapper.Map<QualificationMaster>(Qualification);
                var result = await _connection.qualificationMasters.FirstOrDefaultAsync(x => x.QualificationId == Qualification.QualificationId);
                if (result == null)
                {
                    throw new Exception("It has not updated");
                }
                result.QualificationId = Qualification.QualificationId;
                result.QualificationName = Qualification.QualificationName;
                result.Status = Qualification.Status;
                result.ModifiedBy = Qualification.ModifiedBy;
                result.CreatedBY = Qualification.CreatedBY;
                result.CreatedOn = Qualification.CreatedOn;
                result.ModifiedOn = Qualification.ModifiedOn;
                _connection.qualificationMasters.Update(result);
                await _connection.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
