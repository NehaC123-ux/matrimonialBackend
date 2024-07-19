using AutoMapper;
using MatrimonialBusinessAccess_Layer.Interfaceservice;
using MatrimonialDataAccess_Layer.DatabaseContext;
using MatrimonialModel_Layer.DTO;
using MatrimonialModel_Layer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrimonialBusinessAccess_Layer.RepoService
{
    public class NewRegistrationService:INewRegistrationService
    {
        private readonly AppDbConnection _connection;
        private readonly IMapper _mapper;
        public NewRegistrationService(AppDbConnection connection, IMapper mapper)
        {
            this._connection = connection;
            this._mapper=mapper;
        }

        public async Task<Guid> AddNewRagistrationData(NewRegistrationDtoModel model)
        {
            try
            {
                 var mapp=_mapper.Map<NewRegistrationModel>(model);
                 await _connection.NewRegistrationModels.AddAsync(mapp);
                await _connection.SaveChangesAsync();
                return mapp.ProfileId;
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteNewRegistration(Guid profileId)
        {
            try
            {
                var result=await _connection.NewRegistrationModels.FirstOrDefaultAsync(x=>x.ProfileId==profileId);
                if (result == null)
                {
                    throw new Exception("Can not Be Delete");

                }
                 _connection.NewRegistrationModels.Remove(result);
                await _connection.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<object> getRegistrationAllDropdown()
        {
            var result = from NewRegistrationModel in _connection.NewRegistrationModels
                         join SubCasteMaster in _connection.subCasteMasters on NewRegistrationModel.SubCasteId equals SubCasteMaster.SubCasteId
                         join GotraMaster in _connection.gotraMasters on NewRegistrationModel.GotraId equals GotraMaster.GotraId
                         join DistrictMaster in _connection.DistrictMasters on NewRegistrationModel.DistrictId equals DistrictMaster.DistrictId
                         join ProfessionMaster in _connection.professionMasters on NewRegistrationModel.ProfessionId equals ProfessionMaster.ProfessionId
                         join QualificationMaster in _connection.qualificationMasters on NewRegistrationModel.QualificationId equals QualificationMaster.QualificationId
                         join CountryMaster in _connection.CountryMasters on NewRegistrationModel.CountryId equals CountryMaster.CountryId
                         join StateMaster in _connection.StateMasters on NewRegistrationModel.StateId equals StateMaster.StateId
                         join profileImage in _connection.multipleImageProfiles on NewRegistrationModel.ProfileId equals profileImage.ProfileId
                         select new
                         {
                             ProfileId=NewRegistrationModel.ProfileId,
                             Location = NewRegistrationModel.Location,
                             Religion = NewRegistrationModel.Religion,
                             Age = NewRegistrationModel.Age,
                             MaritalStatus = NewRegistrationModel.MaritalStatus,
                             Height = NewRegistrationModel.Height,
                             Caste = NewRegistrationModel.Caste,
                             Complexion = NewRegistrationModel.Complexion,
                             SubCasteMaster = SubCasteMaster.SubCasteName,
                             HomeLocation = NewRegistrationModel.HomeLocation,
                             GotraMaster = GotraMaster.GotraName,
                             DistrictMaster = DistrictMaster.DistrictName,
                             QualificationMaster = QualificationMaster.QualificationName,
                             StateMaster = StateMaster.StateName,
                             ProfessionMaster = ProfessionMaster.ProfessionName,
                             CountryMaster = CountryMaster.CountryName,
                             Profile=profileImage.ProfileName,
                             Profile1=profileImage.ProfileName1,
                             Profile2=profileImage.ProfileName2,
                        //    Profile = NewRegistrationModel.multipleImageProfiles.Select(x => (new { x.ProfileName, x.ProfileName1, x.ProfileName2 })).ToList()
                         };
            return result;

        }

        public async Task<List<NewRegistrationDtoModel>> GetNewRegistrationList()
        { 
            try
            {
                var result = await _connection.NewRegistrationModels.Include(x=>x.multipleImageProfiles).ToListAsync();
                var mapp=_mapper.Map<List<NewRegistrationDtoModel>>(result);
                return mapp;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<NewRegistrationDtoModel> GetNewRegistrationRecordById(Guid profileId)
        {
            try
            {
                var  result= await _connection.NewRegistrationModels.FirstOrDefaultAsync(x=>x.ProfessionId==profileId);
                var map=_mapper.Map<NewRegistrationDtoModel>(result);
                return map;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
          
        }

        public async Task UpdateNewRegistrationRecord(NewRegistrationDtoModel newRegistration)
        {
            try
            {
                var mapp = _mapper.Map<NewRegistrationDtoModel>(newRegistration);
                var result = await _connection.NewRegistrationModels.FirstOrDefaultAsync(x => x.ProfessionId == newRegistration.ProfessionId);
                if (result == null)
                {
                    throw new Exception("Can Not be Update");
                }
                result.ProfileId = newRegistration.ProfileId;
                result.Religion = newRegistration.Religion;
                result.Location = newRegistration.Location;
                result.HomeLocation = newRegistration.HomeLocation;
                result.Age = newRegistration.Age;
                result.Caste=newRegistration.Caste;
                result.SubCasteId= newRegistration.SubCasteId;
                result.StateId= newRegistration.StateId; 
                result.ProfessionId=newRegistration.ProfessionId;
                result.QualificationId=newRegistration.QualificationId;
                result.DistrictId=newRegistration.DistrictId;
                result.Complexion=newRegistration.Complexion;
                result.MaritalStatus=newRegistration.MaritalStatus;
                result.Height=newRegistration.Height;
                result.GotraId=newRegistration.GotraId; 
               
                _connection.NewRegistrationModels.Update(result);
                await _connection.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
