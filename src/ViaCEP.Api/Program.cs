using Refit;

using ViaCEP.Api;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<ApplicationContext>(options =>
//    options.UseNpgsql(builder.Configuration.GetConnectionString("ApplicationContext") ?? throw new InvalidOperationException("Connection string 'ApplicationContext' not found.")));

// Add services to the container.
builder.Services.AddScoped<IEnderecoService, EnderecoService>();

builder.Services.AddRefitClient<IViaCepApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://viacep.com.br/"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();