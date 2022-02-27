using Microsoft.EntityFrameworkCore;
using ShortLink.ApplicationService;
using ShortLink.Infra.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IPageLinkService, PageLinkService>();
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

string connString = builder.Configuration.GetConnectionString("ShortLinkCnn");
builder.Services.AddDbContext<ShortLinkContext>(option => option.UseSqlServer(connString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
