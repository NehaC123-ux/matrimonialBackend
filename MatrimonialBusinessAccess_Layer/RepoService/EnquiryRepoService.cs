using AutoMapper;
using MatrimonialBusinessAccess_Layer.Interfaceservice;
using MatrimonialDataAccess_Layer.DatabaseContext;
using MatrimonialModel_Layer.DTO;
using MatrimonialModel_Layer.Model;
using Microsoft.EntityFrameworkCore;

namespace MatrimonialBusinessAccess_Layer.RepoService
{
    public class EnquiryRepoService : IEnquiryRepoService
    {
        private readonly AppDbConnection _connection;
        private readonly IMapper _mapper;
        public EnquiryRepoService(AppDbConnection connection, IMapper mapper)
        {
            this._connection = connection;
            this._mapper = mapper;
        }

        public async Task AddDetailsEnquiry(EnquiryDto enquiry)
        {
            try
            {
                var map = _mapper.Map<Enquiry>(enquiry);
                await _connection.enquiries.AddAsync(map);
                await _connection.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteDetailsEnquiry(Guid enquiryId)
        {
            try
            {
                var result = await _connection.enquiries.FirstOrDefaultAsync(x => x.EnquiryId == enquiryId);
                if (result == null)
                {
                    throw new Exception("Can not delete");
                }
                _connection.enquiries.Remove(result);
                await _connection.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<EnquiryDto>> GetAllEnquiryList()
        {
            try
            {
                var result = await _connection.enquiries.ToListAsync();
                var map = _mapper.Map<List<EnquiryDto>>(result);
                return map;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<EnquiryDto> GetDetailsEnquiryById(Guid enquiryid)
        {
            try
            {
                var result = await _connection.enquiries.FirstOrDefaultAsync(x => x.EnquiryId == enquiryid);
                var map = _mapper.Map<EnquiryDto>(result);
                return map;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateDetailsEnquiry(EnquiryDto enquiry)
        {
            try
            {
                var map = _mapper.Map<Enquiry>(enquiry);
                var result = await _connection.enquiries.FirstOrDefaultAsync(x => x.EnquiryId == enquiry.EnquiryId);
                if (result == null)
                {
                    throw new Exception("it can not update");
                }
                result.EnquiryId = enquiry.EnquiryId;
                result.EnquiryName = enquiry.EnquiryName;
                result.PhoneNo = enquiry.PhoneNo;
                result.Email = enquiry.Email;
                result.EnquiryFor = enquiry.EnquiryFor;
                result.Status = enquiry.Status;
                result.DOB = enquiry.DOB;
                result.CreatedBY = enquiry.CreatedBY;
                result.CreatedOn = enquiry.CreatedOn;
                result.ModifiedBy = enquiry.ModifiedBy;
                result.ModifiedOn = enquiry.ModifiedOn;
                result.Gender = enquiry.Gender;
                _connection.enquiries.Update(result);
                await _connection.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
