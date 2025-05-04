
using Microsoft.EntityFrameworkCore;
using JengChiInventoryApi.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<InventoryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register controller support
builder.Services.AddControllers(); // << THIS LINE IS REQUIRED

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers(); // This requires AddControllers()
app.Run();





