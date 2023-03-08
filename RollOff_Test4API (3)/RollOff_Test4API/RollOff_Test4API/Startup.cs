using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RollOff_Test4API.Data;
using RollOff_Test4API.Repository;
using RollOff_Test4API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollOff_Test4API
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
            services.AddCors((options) =>//adding corspolicy
            {
                options.AddPolicy("angularapp", (builder) =>
                {
                    builder.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .WithMethods("GET", "POST", "PUT", "DELETE")
                    .WithExposedHeaders("*");

                });
 
            });
            services.AddControllers();
            services.AddDbContext<RollOff4DbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));//setting database connection
            services.AddScoped<IEmployeeDetails, EmployeeDetailsRepository>();
            services.AddScoped<EmployeeService, EmployeeService>();
            services.AddScoped<IRegisterRepository, RegisterRepository>();
            services.AddScoped<Ifeedbackform, feedbackformrepo>();
      
            services.AddTransient<registerservice, registerservice>();
       services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x => {    //jwt authentication 
           x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true, //localhost              


                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "localhost",
                    ValidAudience = "localhost",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["jwtConfig:key"])),
                    ClockSkew = TimeSpan.Zero
                };
            });


            services.AddSwaggerGen(c =>
           {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RollOff_Test4API", Version = "v1" });
           });
            services.AddAutoMapper(typeof(Program).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();// middlewarre
              app.UseSwagger();
               app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RollOff_Test4API v1"));
            }

            app.UseHttpsRedirection();//middleware

            app.UseRouting();//middlewarre
            app.UseCors("angularapp");// middlewarre

            app.UseAuthorization();// middlewarre

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
