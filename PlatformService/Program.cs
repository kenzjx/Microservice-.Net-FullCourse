using Microsoft.EntityFrameworkCore;
using PlatformService.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<AppDbContext>(opts =>
{
    opts.UseInMemoryDatabase("InMem");
});

// builder.Services.AddMvc(options =>
// {
//     options.SuppressAsyncSuffixInActionNames = false;
// });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = "PlatFormService",
            Version = "2.0",
            Contact = new Microsoft.OpenApi.Models.OpenApiContact()
            {
                Name = "do phong",
                Email = "dophong.developer@gmail.com",
                Url = new Uri("https://github.com/kenzjx")
            },
            Description = "Learn Microservice",

        });
    }
);

builder.Services.AddScoped<IPlatformRepo, PlatformRepo>();

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

PrepDb.PrepPopulation(app);

app.Run();
