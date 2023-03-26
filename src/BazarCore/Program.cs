using BazarCore.Data.Context;
using BazarCore.Data.Repository;
using BazarCore.Data.Repository.Interfaces;
using BazarCore.Entities;
using BazarCore.Services;
using BazarCore.Services.Interfaces;
using BazarCore.Services.Validators;
using BazarCore.Utils;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Configuration;

namespace BazarCore.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // swagger config 
            _ = builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Bazar API v1",
                    Version = "v1",
                    Description = "Bazar API",
                    Contact = new OpenApiContact
                    {
                        Name = "Bazar",
                        Email = "developer@Bazar.co.ao",
                        Url = new Uri("https://Bazar.com"),
                    },
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            Array.Empty<string>()
                    }
                });
            });
            //builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //builder.Services.AddIdentity();
            builder.Services.AddAuthentication(x =>
            {
                x.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            }).AddCookie(config =>
               {
                   //config.Cookie.IsEssential = true;
                   config.Cookie.Name = $"bazarAuth.Cookie";
                   config.LoginPath = "/login/index";
                   //config.AccessDeniedPath = "/_401";
                   //config.SlidingExpiration = true;
                   //config.EventsType = typeof(CustomCookieAuthenticationEvents);
               });
            builder.Services.AddAuthorization();

            //builder.Services.AddHttpContextAccessor();
            builder.Services.AddDbContext<MyContext>(options =>
                   options.UseSqlServer(builder.Configuration.GetConnectionString("conn2")));
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped(typeof(CategoryValidator));
            builder.Services.AddScoped(typeof(EventValidator));
            builder.Services.AddScoped(typeof(UserValidator));
            builder.Services.AddScoped(typeof(OrganizerValidator));
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IEventService, EventService>();
            builder.Services.AddScoped<IOrganizerService, OrganizerService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();


            builder.Services.AddControllers();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=home}/{action=index}/{id?}");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                name: "Admin",
                areaName: "Admin",
                pattern: "admin/{controller=Admin}/{action=Index}/{id?}");
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Baza API v1");
            });
            app.UseSwagger();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "Api",
                  pattern: "{api}/{controller=events}/{action=get}/{id?}"
                );
            });
            app.Run();
        }
    }
}