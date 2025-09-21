using MasterNet9.Application;
using MasterNet9.Application.Interfaces;
using MasterNet9.Infrastructure.Reports;
using MasterNet9.Persistence;
using MasterNet9.Persistence.Models;
using MasterNet9.WebApi.Extensions;
using MasterNet9.WebApi.Middleware;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddScoped(typeof(IReportService<>), typeof(ReportService<>));
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddIdentityCore<AppUser> (opt =>
{
    opt.Password.RequireNonAlphanumeric = false;
    opt.User.RequireUniqueEmail = true;
}).AddRoles<IdentityRole>().AddEntityFrameworkStores<MasterNet9DbContext>();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

await app.SeedDataAuthentication();

app.MapControllers();
app.Run();
