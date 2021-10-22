using TimesheetCalendar.Application.CalendarTimeLine;
using TimesheetCalendar.Application.FreeTimeSchedule;
using TimesheetCalendar.Application.ReservationSchedule;
using TimesheetCalendar.Application.TimeSchedule;
using TimesheetCalendar.Sheard;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace TimesheetCalendar
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TimesheetCalendar", Version = "v1" });
            });

            services.AddTransient<IFreeTimeScheduleService, FreeTimeScheduleService>();
            services.AddTransient<ICalendarTimeLineService, CalendarTimeLineService>();
            services.AddTransient<IReservationScheduleService, ReservationScheduleService>();
            services.AddTransient<ITimeScheduleService, TimeScheduleService>();
            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddScoped<IAppSession, AppSession>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TimesheetCalendar v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
