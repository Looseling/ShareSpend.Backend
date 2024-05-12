using SplitWise.Application;
using SplitWise.AddInfrastructure;
using Microsoft.EntityFrameworkCore;
using ShareSpend.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication().
                     AddInfrastructure();

    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDevDB"));
    });
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}