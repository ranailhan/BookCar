
using CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Interfaces;
using CarBook.Persistence.Context;
using CarBook.Persistence.Repositories;

namespace CarBook.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
          


            builder.Services.AddScoped<CarBookContext>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


            builder.Services.AddScoped<GetAboutQueryHandler>();
            builder.Services.AddScoped<GetAboutByIdQueryHandler>();
            builder.Services.AddScoped<CreateAboutCommandHandler>();
            builder.Services.AddScoped<UpdateAboutCommandHandler>();
            builder.Services.AddScoped<RemoveAboutCommandHandler>();

            builder.Services.AddScoped<GetBannerQueryHandler>();
            builder.Services.AddScoped<GetBannerByIdQueryHandler>();
            builder.Services.AddScoped<CreateBannerCommandHandler>();
            builder.Services.AddScoped<UpdateBannerCommandHandler>();
            builder.Services.AddScoped<RemoveBannerCommandHandler>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddControllers();
           
            var app = builder.Build();

       

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI();
            app.MapControllers();

           

            app.Run();
        }
    }
}
