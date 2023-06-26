using api_projeto_final.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Options;
using System.Text.Json.Serialization;

namespace api_projeto_final
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            string[] origins = { "https://localhost:7284/", "http://localhost:3000" };

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    policy =>
                    {
                        policy.WithOrigins(origins).AllowAnyMethod().AllowAnyHeader().AllowCredentials();
                    });

                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.WithOrigins(origins).AllowAnyMethod().AllowAnyHeader().AllowCredentials();
                    });
            }

           );

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            ;
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddDbContext<DbConnect>();

            // add some configurations to save the cookies on browser
            builder.Services.Configure<CookiePolicyOptions>(options =>
            {
                options.ConsentCookie.IsEssential = true;
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
                options.ConsentCookie.SecurePolicy = CookieSecurePolicy.None;
            });

            var authScheme = "cookie";
            builder.Services.AddAuthentication(authScheme) //CookieAuthenticationDefaults.AuthenticationScheme
                .AddCookie(authScheme, options =>
                {
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                    options.Cookie.SameSite = SameSiteMode.None;
                    options.AccessDeniedPath = "/api/login/teste";
                    options.ExpireTimeSpan = TimeSpan.FromHours(2);
                });

           

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

            app.UseCors(MyAllowSpecificOrigins);
            app.UseCors();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers().RequireCors(MyAllowSpecificOrigins);

            app.Run();
        }
    }
}