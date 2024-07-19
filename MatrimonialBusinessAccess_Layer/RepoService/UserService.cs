using AutoMapper;
using Matrimonial.GlobleExceptionHandling.Utility.Exceptions;
using MatrimonialBusinessAccess_Layer.Interfaceservice;
using MatrimonialDataAccess_Layer.DatabaseContext;
using MatrimonialModel_Layer.DTO;
using MatrimonialModel_Layer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UnauthorizedAccessException = Matrimonial.GlobleExceptionHandling.Utility.Exceptions.UnauthorizedAccessException;

namespace MatrimonialBusinessAccess_Layer.RepoService
{
    public class UserService:IUserService
    {
        private readonly AppDbConnection _connection;
        private readonly IMapper _mapper;
        public UserService(AppDbConnection connection, IMapper mapper)
        {
            this._connection = connection;
            this._mapper = mapper;
        }

        public async Task AddRegistration(RegisterModelDto registerModelDto)
        {
            if(registerModelDto == null)
            {
                throw new Exception("not found");
            }
            var res = _mapper.Map<RegisterModel>(registerModelDto);
            await _connection.RegisterTable.AddAsync(res);
            await _connection.SaveChangesAsync();
        }

        public async Task<List<RegisterModelDto>> getUserName()
        {
            var result = await _connection.RegisterTable.ToListAsync();
            var mapp = _mapper.Map<List<RegisterModelDto>>(result);
            return mapp;
           
        }

        public async Task<string> LoginUser(LoginDtoModel dtoModel)
        {
            try { 
                if (await _connection.RegisterTable.AllAsync(x=>x.UserName!=dtoModel.UserName))
                {
                    throw new BadRequestException("EMAIL_NOT_FOUND");
                }
                else if (await _connection.RegisterTable.AllAsync(x => x.Password != dtoModel.Password))
                {
                    throw new BadRequestException("INVALID_PASSWORD");
                }
                var result = await _connection.RegisterTable.FirstOrDefaultAsync(x => x.UserName == dtoModel.UserName && x.Password == dtoModel.Password);
                if (result == null)
                {
                    throw new UnauthorizedAccessException("Unauthorise");
                }
                var token = GenrateJwtToken(result).ToString();
                return token;

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
          
        }
        private string GenrateJwtToken(RegisterModel result)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var sequirityKey = Encoding.UTF32.GetBytes("JwtToken:SecretKey");
            var tokenDiscriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, result.UserName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(sequirityKey), SecurityAlgorithms.HmacSha256)

            };
            var token = tokenHandler.CreateToken(tokenDiscriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
