using Microsoft.EntityFrameworkCore;
using VortiDex.Infra;
using VortiDex.Infra.Repositories;
using VortiDex.Mapper.Implementations;
using VortiDex.Services;

namespace VortiDex;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        var connString = builder.Configuration
            .GetConnectionString("DefaultConnection");
        
        builder
            .Services.AddDbContext<PokeContext>(option => option.UseSqlServer(connString));

        builder
            .Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddScoped<TrainerServices>();
        builder.Services.AddScoped<TrainerRepository>();
        builder.Services.AddScoped<TrainerMapper>();

        builder.Services.AddScoped<SquadServices>();
        builder.Services.AddScoped<SquadRepository>();
        builder.Services.AddScoped<SquadMapper>();

        builder.Services.AddScoped<SkillServices>();
        builder.Services.AddScoped<SkillRepository>();
        builder.Services.AddScoped<SkillMapper>();

        builder.Services.AddScoped<PokemonServices>();
        builder.Services.AddScoped<PokemonRepository>();
        builder.Services.AddScoped<PokemonMapper>();

        builder.Services.AddScoped<PokeTypeServices>();
        builder.Services.AddScoped<PokeTypeRepository>();
        builder.Services.AddScoped<PokeTypeMapper>();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}