﻿using API.Application_.Repositories.Dish;
using API.Application_.Repositories.Menu;
using API.Application_.Repositories.Reservation;
using API.Application_.Repositories.Restaurant;
using API.Application_.Repositories.Review;
using API.Persistence.Context;
using API.Persistence.Repositories.Dish;
using API.Persistence.Repositories.Menu;
using API.Persistence.Repositories.Reservation;
using API.Persistence.Repositories.Restaurant;
using API.Persistence.Repositories.Review;
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



            services.AddScoped<IReservationReadRepository, ReservationReadRepository>();
            services.AddScoped<IReservationWriteRepository, ReservationWriteRepository>();
            services.AddScoped<IRestaurantReadRepository, RestaurantReadRepository>();
            services.AddScoped<IRestaurantWriteRepository, RestaurantWriteRepository>();
            services.AddScoped<IReviewReadRepository, ReviewReadRepository>();
            services.AddScoped<IReviewWriteRepository, ReviewWriteRepository>();
            services.AddScoped<IMenuReadRepository, IMenuReadRepository>();
            services.AddScoped<IMenuWriteRepository, MenuWriteRepository>();
            services.AddScoped<IDishReadRepository, DishReadRepository>();
            services.AddScoped<IDishWriteRepository, DishWriteRepository>();

        }
    }
}
