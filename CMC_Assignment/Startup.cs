using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Project.Application.Context;
using Project.Application.Dtos.AccountDtos;
using Project.Application.EF.UnitOfWork;
using Project.Application.Extensions.Exceptions;
using Project.Application.Mapper;
using Project.Application.Repositories.AccountRepo;
using Project.Application.Repositories.LoginRepo;
using Project.Application.Services;
using Project.Application.Services.LoginService;
using Project.Application.Validators.AccountValidator;
using System;
using System.Text;


namespace CMC_Assignment
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(option => option.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection")));

            services.AddControllers();
            // Add Authen
            AddAuthentication(services);

            // Add DI
            ConfigureDependencyInjection(services);

            services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            // Add Mapper Dto
            services.AddAutoMapper(typeof(MapperProfile).Assembly);
            ConfigureValidator(services);



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CMC_Assignment", Version = "v1" });
            });
        }

        private void ConfigureDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<DataContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAccountRepository, AccountServiceImp>();
            services.AddScoped<ILogin, LoginServiceImp>();
        }

        public void ConfigureValidator(IServiceCollection services)
        {
            services.AddTransient<IValidator<AccountAddingDto>, AccountAddingValidator>();
            services.AddTransient<IValidator<AccountUpdatingDto>, AccountUpdatingValidator>();
        }

        public void AddAuthentication(IServiceCollection services)
        {
            var tokenValidationParameter = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = Configuration["Jwt:Audience"],
                ValidIssuer = Configuration["Jwt:Issuer"],
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
            };
            services.AddSingleton(tokenValidationParameter);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwt =>
            {
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = tokenValidationParameter;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CMC_Assignment v1"));
            }
            app.ConfigureExceptionHandler();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
