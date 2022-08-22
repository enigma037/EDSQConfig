using EDSQConfig.UI.Infrastructure;
using EDSQConfig.UI.Interfaces;
using EDSQConfig.UI.Services;

namespace EDSQConfig.UI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            services.AddControllersWithViews();          
           
            services.AddScoped<IConfigurationDefinitionService, ConfigurationDefinitionService>();
            services.AddScoped<IApplicationConfigurationService, ApplicationConfigurationService>();
            services.AddHttpClient<IAPIService, ApiService>(httpClient =>
            {
                httpClient.BaseAddress = new Uri(Configuration.GetValue<string>("Application:API"));
            });
            services.AddHttpContextAccessor();
        }

        public void Configure(IApplicationBuilder app,
                              IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // auth before endpoints
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
