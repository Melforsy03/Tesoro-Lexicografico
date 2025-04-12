using Microsoft.EntityFrameworkCore;
using MiProyecto.Application.Interfaces;
using MiProyecto.Infrastructure.Persistence;
using MiProyecto.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);


AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAcepcionService, AcepcionService , IDictionaryService , DictionaryService ,IEditorService, EditorService, IMetadatosService ,MetaDatosService , ITerminoService , TerminoService , IDictionaryTerminoService , DictionaryTerminoService ,ISubEntradaService, SubEntradaService>();

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
