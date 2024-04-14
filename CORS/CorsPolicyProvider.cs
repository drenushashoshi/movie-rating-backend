using Microsoft.Extensions.DependencyInjection;

public class CorsPolicyProvider
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin",
                builder =>
                {
                    builder.AllowAnyOrigin()
                    //ose builder.WithOrigins("linku")
                    //brenda mund te shkruajm linkun e faqes/ve nga te cilat lejohen requests
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
        });

        
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseCors("AllowSpecificOrigin"); // Enable CORS

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
