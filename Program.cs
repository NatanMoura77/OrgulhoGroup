using Microsoft.EntityFrameworkCore;
using VortiDex.Infra;
using VortiDex.Infra.Repositories;
using VortiDex.Infra.Repositories.Interfaces;
using VortiDex.Mapper.Implementations;
using VortiDex.Mapper.Interfaces;
using VortiDex.Services;
using VortiDex.Services.Interface;

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
            .Services.AddDbContext<PokeContext>(option => option
            .UseSqlServer(connString));

        builder
            .Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddScoped<ITrainerService, TrainerServices>();
        builder.Services.AddScoped<ITrainerRepository, TrainerRepository>();
        builder.Services.AddScoped<ITrainerMapper, TrainerMapper>();

        builder.Services.AddScoped<ISquadService, SquadServices>();
        builder.Services.AddScoped<ISquadRepository, SquadRepository>();
        builder.Services.AddScoped<ISquadMapper, SquadMapper>();

        builder.Services.AddScoped<ISkillService, SkillServices>();
        builder.Services.AddScoped<ISkillRepository, SkillRepository>();
        builder.Services.AddScoped<ISkillMapper, SkillMapper>();

        builder.Services.AddScoped<IPokemonService, PokemonServices>();
        builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
        builder.Services.AddScoped<IPokemonMapper, PokemonMapper>();

        builder.Services.AddScoped<IPokeTypeService, PokeTypeServices>();
        builder.Services.AddScoped<IPokeTypeRepository, PokeTypeRepository>();
        builder.Services.AddScoped<IPokeTypeMapper, PokeTypeMapper>();

        builder.Services.AddScoped<IPokedexService, PokedexServices>();
        builder.Services.AddScoped<IPokedexRepository, PokedexRepository>();
        builder.Services.AddScoped<IPokedexMapper, PokedexMapper>();

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