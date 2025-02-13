using Microsoft.EntityFrameworkCore;
using SM_Horarios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IClientHandler, ClientHandler>();
builder.Services.AddTransient<IEmployeeHandler, EmployeeHandler>();
builder.Services.AddTransient<IFirmHandler, FirmHandler>();
builder.Services.AddTransient<IMarkedTimeHandler, MarkedTimeHandler>();

builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("InMemoryDb"));

builder.Services.AddAutoMapper(typeof(DTOMappingProfile));

/*builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        "WIN-T0TUUU3CIMK/SQLEXPRESS;Database=master;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;"
    )
);
*/
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();

app.Run();
