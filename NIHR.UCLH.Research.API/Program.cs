using NIHR.UCLH.Research.DAL.DataService.Interface;
using NIHR.UCLH.Research.DAL.DataService.Implementation;
using NIHR.UCLH.Research.DAL.NIHR.UCLH.Research.DAL;
using Microsoft.EntityFrameworkCore;
using NIHR.UCLH.Research.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDataService, DataService>();
builder.Services.AddDbContextFactory<NIHRUCLHResearchDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AppContext")));



builder.Services.AddCors(policy =>
{
    policy.AddPolicy("CorsPolicy", opt => opt
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<NIHRUCLHResearchDBContext>();
    context.Database.EnsureCreated();
    DbInitializer.ReadCsv(context);
}


app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
