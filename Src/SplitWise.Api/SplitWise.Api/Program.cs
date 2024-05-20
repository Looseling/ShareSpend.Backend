using SplitWise.Application;
using SplitWise.AddInfrastructure;
using Microsoft.EntityFrameworkCore;
using ShareSpend.Infrastructure.Data;
using Azure.Storage.Blobs;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication().
                     AddInfrastructure().
    AddApplication();

    builder.Services.AddSingleton(x => new BlobServiceClient(builder.Configuration["Azure:BlobStorage:ConnectionString"])); // find better place for this
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