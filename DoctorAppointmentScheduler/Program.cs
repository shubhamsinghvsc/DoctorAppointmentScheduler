
using DoctorAppointmentScheduler.DataAccess.Contexts;
using DoctorAppointmentScheduler.DataAccess.Repositories.Interfaces;
using DoctorAppointmentScheduler.DataAccess.Repositories.Repositories;
using DoctorAppointmentScheduler.Services.Interfaces;
using DoctorAppointmentScheduler.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DoctorAppointmentScheduler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllers();


            // Configure DbContext with SQL Server
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
      .AddJwtBearer(options =>
      {
          options.TokenValidationParameters = new TokenValidationParameters
          {
              ValidateIssuer = true,
              ValidateAudience = true,
              ValidateLifetime = true,
              ValidateIssuerSigningKey = true,
              ValidIssuer = builder.Configuration["Jwt:Issuer"],
              ValidAudience = builder.Configuration["Jwt:Audience"],
              IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
          };
      });


            builder.Services.AddEndpointsApiExplorer(); // Add this if using .NET 6 or later
            builder.Services.AddSwaggerGen(); // Add this to configure Swagger

            //// Register your repositories
            builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            builder.Services.AddScoped<IPatientRepository, PatientRepository>();
            builder.Services.AddScoped<IHolidaysRepository, HolidaysRepository>();
            builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
            builder.Services.AddScoped<ILeaveRepository, LeaveRepository>();
            builder.Services.AddScoped<ITimeAvailabilityRepository, TimeAvailabilityRepository>();
            builder.Services.AddScoped<IUsersRepository, UsersRepository>();


            //// Register your services
            builder.Services.AddScoped<IAppointmentService, AppointmentService>();
            builder.Services.AddScoped<IPatientService, PatientService>();
            builder.Services.AddScoped<IHolidaysService, HolidaysService>();
            builder.Services.AddScoped<IDoctorService, DoctorService>();
            builder.Services.AddScoped<ILeaveService, LeaveService>();
            builder.Services.AddScoped<ITimeAvailabilityService, TimeAvailabilityService>();
            builder.Services.AddScoped<ISlotService, SlotService>();
            builder.Services.AddScoped<ITokenService, TokenService>();

            //// Register AutoMapper if used
            //builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin()   // Allow any origin
                               .AllowAnyMethod()   // Allow any HTTP method (GET, POST, etc.)
                               .AllowAnyHeader();  // Allow any HTTP header
                    });
            });

            var app = builder.Build();


            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.EnsureCreated();
            }


            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger(); // Enable Swagger in development
                app.UseSwaggerUI(); // Enable Swagger UI in development
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseCors("AllowAll");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();

        }
    }
}
