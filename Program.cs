using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PGManagement.DataLayer;
using PGManagement.Exception_Handling;
using PGManagement.Respository;
using Serilog;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DBContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("SqlDbConnection"),
    providerOptions => providerOptions.EnableRetryOnFailure()));

builder.Services.AddScoped<IAdmin,Admin>();
builder.Services.AddApiVersioning(x =>
{
    x.DefaultApiVersion = new ApiVersion(1, 0);
    x.AssumeDefaultVersionWhenUnspecified = true;
    x.ReportApiVersions = true;
});
builder.Services.AddCors(option => { option.AddDefaultPolicy(b => b.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod()); });
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseExceptionHandler(
 options => {
     options.Run(
     async context =>
     {
         context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
         context.Response.ContentType = "text/html";
         var ex = context.Features.Get<IExceptionHandlerFeature>();
         if (ex != null)
         {
             var err = $"<h1>Error: {ex.Error.Message}</h1>{ex.Error.StackTrace}";
             await context.Response.WriteAsync(err).ConfigureAwait(false);
         }
     });
 }
);
app.UseSerilogRequestLogging();
app.UseCors();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
