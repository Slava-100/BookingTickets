using BookingTickets;
using BookingTickets.Business;
using BookingTickets.DataLayer;
using BookingTickets.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.ConfigureApiServices();
builder.Services.ConfigureBllServices();
builder.Services.ConfigureDataBase(builder.Configuration);
builder.Services.ConfigureDalServices();
builder.Services.AddAutoMapper(typeof(FilmProfile));

var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();

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
