using Matchplanner.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Use an in memory database so you don't have to set anything up. SqlServer is better, though.
        builder.Services.AddDbContextFactory<BioscoopContext>(
            options => options.UseInMemoryDatabase("BioscoopDatabase"));

        // Add services to the container.
        builder.Services.AddSingleton<ITicketService, TicketService>();
        builder.Services.AddSingleton<IRoomService, RoomService>();
        builder.Services.AddSingleton<IMovieService, MovieService>();

        // Add CORS configuration
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            TokenService.GetTokenValidationParameters(builder.Configuration);
    });
        builder.Services.AddTransient<ITokenService, TokenService>()
                        .AddTransient<IAuthService, AuthService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseCors();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}