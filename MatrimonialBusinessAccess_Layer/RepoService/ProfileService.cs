using AutoMapper;
using MatrimonialBusinessAccess_Layer.Interfaceservice;
using MatrimonialDataAccess_Layer.DatabaseContext;
using MatrimonialModel_Layer.DTO;  
using MatrimonialModel_Layer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatrimonialBusinessAccess_Layer.RepoService
{
    public class ProfileService : IProfileService
    {
        private readonly AppDbConnection _connection;
        private readonly IMapper _mapper;
        public ProfileService(AppDbConnection connection,IMapper mapper)
        {
            this._connection = connection;
            this._mapper = mapper;
        }

        public async Task uploadImage([FromForm] IFormFile[] file , [FromForm] Guid ProfileId)
        {
            MultipleImageProfileDto multipleImageProfileDto = new MultipleImageProfileDto();
            if (file != null && file.Length > 0)
            {
                foreach (var files in file)
                {
                    multipleImageProfileDto.ProfileId=ProfileId;

                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(files.FileName);
                    var filePath = Path.Combine("Assets/Image", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await files.CopyToAsync(stream);
                    }
                    if (multipleImageProfileDto.ProfileName == null)
                    {
                        multipleImageProfileDto.ProfileName = fileName;
                    }
                    else if (multipleImageProfileDto.ProfileName1 == null)
                    {
                        multipleImageProfileDto.ProfileName1 = fileName;
                    }
                    else
                    {
                        multipleImageProfileDto.ProfileName2 = fileName;
                    }
                }
                 var map = _mapper.Map<MultipleImageProfile>(multipleImageProfileDto);
                await _connection.multipleImageProfiles.AddRangeAsync(map);
                await _connection.SaveChangesAsync();
            }
        }
    }
}
