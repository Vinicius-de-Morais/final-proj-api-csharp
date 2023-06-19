using api_projeto_final.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace api_projeto_final
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddDbContext<DbConnect>();

            var authScheme = "cookie";
            builder.Services.AddAuthentication(authScheme)
                .AddCookie(authScheme);

            /*builder.Services.AddAuthorization(builder =>
            {
                builder.AddPolicy("login_token", pb =>
                {
                    pb.RequireAuthenticatedUser()
                        .AddAuthenticationSchemes(authScheme)
                        .RequireClaim("token", "teste");
                });
            });*/

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("login_token", policy =>
                {
                    policy.RequireAuthenticatedUser()
                        .AddAuthenticationSchemes(authScheme)
                        .AddRequirements(new AuthReq());
                });
            });

            builder.Services.AddSingleton<IAuthorizationHandler, TokenValidationHandler>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}