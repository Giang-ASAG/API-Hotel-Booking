
using DH52110843_BLL.HostedServices;
using DH52110843_BLL.Interfaces;
using DH52110843_BLL.Mapping;
using DH52110843_BLL.Services;
using DH52110843_BLL.UnitOfWork;
using DH52110843_DAL.Data;
using DH52110843_DAL.Interfaces;
using DH52110843_DAL.Models;
using DH52110843_DAL.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DH52110843_api_quan_ly_khach_san_homestay
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            // Add services to the container.
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.Configure <JwtClass>(builder.Configuration.GetSection("JWT"));
            builder.Services.AddDbContext<HethonghotelContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.Parse("8.2.0-mysql"));
            });
            var jwtSecret = builder.Configuration["JWT:Secret"];
            var key = Encoding.ASCII.GetBytes(jwtSecret);
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false, // hoặc true nếu có cấu hình issuer
                    ValidateAudience = false, // hoặc true nếu có cấu hình audience
                    ClockSkew = TimeSpan.Zero
                };
            });

            builder.Services.AddAuthorization();

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddScoped<IUserDocumentRepository, UserDocumentRepository>();
            builder.Services.AddScoped<IUserDocumentService, UserDocumentService>();

            builder.Services.AddScoped<IBookingRepository, BookingRepository>();
            builder.Services.AddScoped<IBookingService, BookingService>();

            builder.Services.AddScoped<IHotelRepository, HotelRepository>();
            builder.Services.AddScoped<IHotelService, DH52110843_BLL.Services.HotelService>();

            builder.Services.AddScoped<IHotelImageRepository, HotelImageRepository>();
            builder.Services.AddScoped<IHotelImageService, HotelImageService>();

            builder.Services.AddScoped<IHotelImageStorageRepository, HotelImageStorageRepository>();
            builder.Services.AddScoped<IHotelImageStorageService, HotelImageStorageService>();

            builder.Services.AddScoped<IHotelServiceRepository, HotelServiceRepository>();
            builder.Services.AddScoped<IHotelServiceService, HotelServiceService>();

            builder.Services.AddScoped<IRoomRepository, RoomRepository>();
            builder.Services.AddScoped<IRoomService, DH52110843_BLL.Services.RoomService>();

            builder.Services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
            builder.Services.AddScoped<IRoomTypeService, RoomTypeService>();


            builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
            builder.Services.AddScoped<IPaymentService, PaymentService>();

            builder.Services.AddScoped<IRoomImageRepository, RoomImageRepository>();
            builder.Services.AddScoped<IRoomImageService, RoomImageService>();

            builder.Services.AddScoped<IRoomImagesStorageRepository, RoomImagesStorageRepository>();
            builder.Services.AddScoped<IRoomImagesStorageService, RoomImagesStorageService>();

            builder.Services.AddScoped<IRoomServiceRepository, RoomServiceRepository>();
            builder.Services.AddScoped<IRoomService_Service, RoomService_Service>();

            builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
            builder.Services.AddScoped<IReviewService, ReviewService>();

            builder.Services.AddScoped<IEmailService, EmailService>();

            builder.Services.AddHostedService<BackgroundTaskHostedService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1"
                });

                // Thêm cấu hình xác thực Bearer Token
                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Description = "Nhập JWT vào đây theo định dạng: Bearer {token}",
                    Name = "Authorization",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                {
                    {
                        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                        {
                            Reference = new Microsoft.OpenApi.Models.OpenApiReference
                            {
                                Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            
            var app = builder.Build();

                app.UseSwagger();
                app.UseSwaggerUI();


            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
