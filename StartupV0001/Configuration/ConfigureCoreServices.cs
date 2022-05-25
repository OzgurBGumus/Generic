using Authentication;
using Core.Interfaces.Authentication;
using Core.Interfaces.User;
using Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using P_Core.Interfaces.Data;
using P_StartupV0001;
using P_StartupV0001.Helpers;
using System.Text;
using User;

namespace StartupV0001.Configuration
{
    public static class ConfigureCoreServices
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services,
        IConfiguration configuration)
        {
            //services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
            //services.AddScoped<IBasketService, BasketService>();
            //services.AddSingleton<IUriComposer>(new UriComposer(configuration.Get<CatalogSettings>()));
            services.AddDbContext<P_StartupV0001.DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            ServiceProvider serviceProvider = services.BuildServiceProvider();
            DataContext appDbContext = serviceProvider.GetService<DataContext>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IDataAccessService, DataService>(uow => new DataService(appDbContext));
            services.AddControllers();

            
            AppSettings(services, configuration);
            Cors(services, configuration);
            Swagger(services, configuration);
            Auth(services, configuration);
            return services;
        }

        private static void AppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
        }
        private static void Cors(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors();
        }
        private static void Swagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
        private static void Auth(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthorization();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["AppSettings:JwtSecret"])),
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
    }
}
