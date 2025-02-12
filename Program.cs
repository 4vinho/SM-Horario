using Microsoft.EntityFrameworkCore;
using SM_Horarios;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("InMemoryDb"));


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        "WIN-T0TUUU3CIMK/SQLEXPRESS;Database=master;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;"
    )
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
