using AutoMapper;
using MatrimonialModel_Layer.Model;

namespace MatrimonialModel_Layer.DTO.Helper
{
    public class ProfileData : Profile
    {
        public ProfileData()
        {
            CreateMap<CountryMaster, CountryDto>().ReverseMap();
            //Countrymaster and CountryDto Are Mappped
            CreateMap<StateMaster, StateDto>().ReverseMap();
            //StateMaster and StateDto are mapped
            CreateMap<DistrictMaster, DistrictDto>().ReverseMap();
            //districtMaster and DistrictDto are mapped
            CreateMap<QualificationMaster, QualificationDto>().ReverseMap();
            //QualificationMaster and Qualification are mapped
            CreateMap<SubCasteMaster, SubCasteDto>().ReverseMap();
            //SubCastemaster and SubcasteDto are mappped
            CreateMap<GotraMaster, GotraDto>().ReverseMap();
            //GotraMaster and GotraDto are mapped
            CreateMap<Enquiry, EnquiryDto>().ReverseMap();
            //Enquiry and EnquiryDto are Mapped
            CreateMap<ProfessionMaster, ProfessionDto>().ReverseMap();
            //ProfessionMaster and ProfessionDto are mapped
            CreateMap<MultipleImageProfile, MultipleImageProfileDto>().ReverseMap();
            //MultipleImageProfile and MultipleImageProfileDto are Mapped
          
            //LoginModel and LoginDto Are Mapped
            CreateMap<RegisterModel,RegisterModelDto>().ReverseMap();

            //NewRegistrationModel and NewRegistrationDtoModel are Mapped
            CreateMap<NewRegistrationModel,NewRegistrationDtoModel>().ReverseMap(); 

        }
    }
}
