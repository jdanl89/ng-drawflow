using System.Text.Json.Serialization;
using Drawflow.Server.Data;
using Drawflow.Server.Services;
using Microsoft.AspNetCore.Http.Features;
using Serilog;

WebApplicationBuilder _builder = WebApplication.CreateBuilder(args);

_builder.Services.Configure<FormOptions>(opt =>
{
    opt.ValueLengthLimit = int.MaxValue;
    opt.MultipartBodyLengthLimit = int.MaxValue;
    opt.MemoryBufferThreshold = int.MaxValue;
});

_builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(_builder.Configuration));

// Add services to the container.
_builder.Services.AddScoped<IFileService, FileService>();
_builder.Services.AddScoped<IFormService, FormService>();
_builder.Services.AddScoped<IModuleService, ModuleService>();
_builder.Services.AddScoped<IWorkflowService, WorkflowService>();

// TODO: Add repositories
_builder.Services.AddDbContext<AppDbContext>();

_builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
_builder.Services.AddEndpointsApiExplorer();
_builder.Services.AddSwaggerGen();

WebApplication _app = _builder.Build();

using (IServiceScope _scope = _app.Services.CreateScope())
{
    AppDbContext _dbContext = _scope.ServiceProvider.GetRequiredService<AppDbContext>();
    _dbContext.SeedData();
}

_app.UseDefaultFiles();
_app.UseStaticFiles();

_app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (_app.Environment.IsDevelopment())
{
    _app.UseSwagger();
    _app.UseSwaggerUI();
}

_app.UseHttpsRedirection();

_app.UseAuthorization();

_app.MapControllers();

_app.MapFallbackToFile("/index.html");

_app.Run();