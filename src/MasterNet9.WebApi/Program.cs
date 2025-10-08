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
builder.Services.AddPoliciesServices();
builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection(nameof(CloudinarySettings)));
builder.Services.AddScoped<IPhotoService, PhotoService>();
builder.Services.AddScoped(typeof(IReportService<>), typeof(ReportService<>));
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerDocumentation();
builder.Services.AddCors(o => o.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.useSwaggerDocumentation();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("corsapp");

await app.SeedDataAuthentication();

app.MapControllers();
app.Run();
