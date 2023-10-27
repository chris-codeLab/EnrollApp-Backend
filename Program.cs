using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Persistence;
using Persistence.Repositories;
using Services;
using Services.Abstractions;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Models;
using Web.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllers()
                .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

        builder.Services.AddSwaggerGen(c =>
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web", Version = "v1" }));

        builder.Services.AddScoped<IServiceManager, ServiceManager>();

        builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

        builder.Services.AddDbContext<EnrollAppContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("EnrollAppContext")));


        builder.Services.AddTransient<ExceptionHandlingMiddleware>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMiddleware<ExceptionHandlingMiddleware>();

}

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    { 
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web v1");
        c.RoutePrefix = String.Empty;
    });

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
    
app.UseEndpoints(endpoints => endpoints.MapControllers());


app.Run();
