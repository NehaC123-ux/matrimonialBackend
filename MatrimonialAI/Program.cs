
using MatrimonialAI.GlobleExceptionHandling;
using MatrimonialBusinessAccess_Layer.Interfaceservice;
using MatrimonialBusinessAccess_Layer.RepoService;
using MatrimonialDataAccess_Layer.DatabaseContext;
using MatrimonialModel_Layer.DTO.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MatrimonialAI
{
    public class Program
    {
        public static void Main(string[] args)
          {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                 .AddNewtonsoftJson(options =>
                 {
                     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                     // Add other settings as needed
                 });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "your_issuer",
                    ValidAudience = "your_audience",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JwtToken:SecretKey")),
                };
            });
            builder.Services.AddScoped<ICountryRepoService, CountryRepoService>();
            builder.Services.AddScoped<IStateRepoService, StateRepoService>();
            builder.Services.AddScoped<IDistrictRepoService, DistrictRepoService>();
            builder.Services.AddScoped<IQualificationRepoService, QualificationRepoService>();
            builder.Services.AddScoped<ISubCasteRepoService, SubCasteRepoService>();
            builder.Services.AddScoped<IGotraRepoService, GotraRepoService>();
            builder.Services.AddScoped<IEnquiryRepoService, EnquiryRepoService>();
            builder.Services.AddScoped<IProfessionRepoService, ProfessionRepoService>();
            builder.Services.AddScoped<IProfileService,ProfileService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<INewRegistrationService, NewRegistrationService>();
            builder.Services.AddDbContext<AppDbConnection>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("Required"));
            });
            builder.Services.AddAutoMapper(typeof(ProfileData));

            builder.Services.AddCors(option =>
            {
                option.AddPolicy("Matrimonial", builder =>
                {
                    builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseCors("Matrimonial");
            }
            app.UseMiddleware(typeof(GlobalErrorHandlingMiddleware));
            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Assets/Image")),
                RequestPath = "/Assets/Image"
            });
            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Assets/Image")),
                RequestPath = "/Assets/Image"

            });


            app.MapControllers();

            app.Run();
        }
    }
}