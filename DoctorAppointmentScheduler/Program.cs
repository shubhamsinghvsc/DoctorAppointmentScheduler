
using DoctorAppointmentScheduler.DataAccess.Contexts;
using DoctorAppointmentScheduler.DataAccess.Repositories.Interfaces;
using DoctorAppointmentScheduler.DataAccess.Repositories.Repositories;
using DoctorAppointmentScheduler.Services.Interfaces;
using DoctorAppointmentScheduler.Services.Services;
using Microsoft.EntityFrameworkCore;

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


            builder.Services.AddEndpointsApiExplorer(); // Add this if using .NET 6 or later
            builder.Services.AddSwaggerGen(); // Add this to configure Swagger

            //// Register your repositories
            builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            builder.Services.AddScoped<IPatientRepository, PatientRepository>();
            //builder.Services.AddScoped<ISlotRepository, SlotRepository>();
            builder.Services.AddScoped<IHolidaysRepository, HolidaysRepository>();
            builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
            builder.Services.AddScoped<ILeaveRepository, LeaveRepository>();
            builder.Services.AddScoped<ITimeAvailabilityRepository, TimeAvailabilityRepository>();


            //// Register your services
            builder.Services.AddScoped<IAppointmentService, AppointmentService>();
            builder.Services.AddScoped<IPatientService, PatientService>();
            //builder.Services.AddScoped<ISlotService, SlotService>();
            builder.Services.AddScoped<IHolidaysService, HolidaysService>();
            builder.Services.AddScoped<IDoctorService, DoctorService>();
            builder.Services.AddScoped<ILeaveService, LeaveService>();
            builder.Services.AddScoped<ITimeAvailabilityService, TimeAvailabilityService>();
            builder.Services.AddScoped<ISlotService, SlotService>();

            //// Register AutoMapper if used
            //builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();

        }
    }
}
