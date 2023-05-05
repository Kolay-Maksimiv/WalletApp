using WalletApp.API.Extensions;
using WalletApp.API.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDatabase(builder.Configuration);

builder.Services.AddSwaggerConfiguration();

builder.Services.AddEntityRepositories();

builder.Services.AddEntityServices();

builder.Services.AddUnitOfWork();

builder.Services.AddAutoMapperConfig();

builder.Services.AddGenericRepository();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
{
    options.AddPolicy("EnableCORS", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseSwaggerBuilder();

app.UseHttpsRedirection();

app.UseMiddleware(typeof(ErrorHandlingMiddleware));

app.UseCors("EnableCORS");

app.UseAuthorization();

app.MapControllers();

app.Run();
