using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TL.Application.Interfaces;
using TL.Application.Services;
using TL.Infrastructure;
var builder = WebApplication.CreateBuilder(args);


AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<Context>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAcepcionService, AcepcionService>();
builder.Services.AddScoped<IDiccionarioService, DiccionarioService>();
builder.Services.AddScoped<IEditorService, EditorService>();
builder.Services.AddScoped<IMetadatosService, MetadatosService>();
builder.Services.AddScoped<ITerminoService, TerminoService>();
builder.Services.AddScoped<IDiccionarioTerminoService, DiccionarioTerminoService>();
builder.Services.AddScoped<ISubEntradaService, SubEntradaService>();

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
