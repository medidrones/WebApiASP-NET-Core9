using MasterNet9.Application;
using MasterNet9.Application.Interfaces;
using MasterNet9.Infrastructure.Photos;
using MasterNet9.Infrastructure.Photosl;
using MasterNet9.Infrastructure.Reports;
using MasterNet9.Persistence;
using MasterNet9.WebApi.Extensions;
using MasterNet9.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection(nameof(CloudinarySettings)));
builder.Services.AddScoped<IPhotoService, PhotoService>();
builder.Services.AddScoped(typeof(IReportService<>), typeof(ReportService<>));
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment()
    || app.Environment.IsStaging()
    || app.Environment.IsProduction())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

await app.SeedDataAuthentication();

app.MapControllers();
app.Run();
