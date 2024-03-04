using Drawflow.Server.Data;
using Drawflow.Server.Services;

WebApplicationBuilder _builder = WebApplication.CreateBuilder(args);

// Add services to the container.
_builder.Services.AddScoped<IFileService, FileService>();
_builder.Services.AddScoped<IFormService, FormService>();
_builder.Services.AddScoped<IModuleService, ModuleService>();
_builder.Services.AddScoped<IWorkflowService, WorkflowService>();

// TODO: Add repositories
_builder.Services.AddDbContext<AppDbContext>();

_builder.Services.AddControllers();
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