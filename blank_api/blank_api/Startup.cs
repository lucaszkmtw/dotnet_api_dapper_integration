namespace API_Pagos
{
    public class Startup
    {
        public IConfiguration configRoot
        {
            get;
        }
        public Startup(IConfiguration configuration)
        {
            configRoot = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
         
            app.UseSwagger();
            app.UseSwaggerUI();
            //}


            if (app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseDeveloperExceptionPage();
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseCors("corsapp");
            app.UseAuthentication(); // Usamos autenticacion JWT

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}
