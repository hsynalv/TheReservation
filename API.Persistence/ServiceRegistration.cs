using API.Application_.Abstractions.Services;
using API.Application_.Abstractions.Services.Authentication;
using API.Application_.Repositories.Dish;
using API.Application_.Repositories.Menu;
using API.Application_.Repositories.Reservation;
using API.Application_.Repositories.Restaurant;
using API.Application_.Repositories.Review;
using API.Domain.Entity.Identity;
using API.Persistence.Context;
using API.Persistence.CustomValidation;
using API.Persistence.Repositories.Dish;
using API.Persistence.Repositories.Menu;
using API.Persistence.Repositories.Reservation;
using API.Persistence.Repositories.Restaurant;
using API.Persistence.Repositories.Review;
using API.Persistence.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace API.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {

            services.AddDbContext<APIDbContext>(options =>
                options.UseSqlServer(Configuration.ConnectionString));

            services.AddIdentity<AppUser, AppRole>(options =>
                {
                    options.User.RequireUniqueEmail = true;
                    options.User.AllowedUserNameCharacters = "abcçdefgðhiýjklmnoöpqrsþtuüvwxyzABCÇDEFGHIÝJKLMNOÖPQRSÞTUÜVWXYZ0123456789-._";


                    options.Password.RequiredLength = 3;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                }).AddPasswordValidator<CustomPasswordValidator>()
                .AddUserValidator<CustomUserValidator>()
                .AddEntityFrameworkStores<APIDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IExternalAuthentication, AuthService>();
            services.AddScoped<IInternalAuthentication, AuthService>();



            services.AddScoped<IReservationReadRepository, ReservationReadRepository>();
            services.AddScoped<IReservationWriteRepository, ReservationWriteRepository>();
            services.AddScoped<IRestaurantReadRepository, RestaurantReadRepository>();
            services.AddScoped<IRestaurantWriteRepository, RestaurantWriteRepository>();
            services.AddScoped<IReviewReadRepository, ReviewReadRepository>();
            services.AddScoped<IReviewWriteRepository, ReviewWriteRepository>();
            services.AddScoped<IMenuReadRepository, MenuReadRepository>();
            services.AddScoped<IMenuWriteRepository, MenuWriteRepository>();
            services.AddScoped<IDishReadRepository, DishReadRepository>();
            services.AddScoped<IDishWriteRepository, DishWriteRepository>();

        }


    }
}
