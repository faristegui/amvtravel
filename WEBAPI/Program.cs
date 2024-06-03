using static WEBAPI.Domain.GestorReservas;
using WEBAPI.Domain;

var builder = WebApplication.CreateBuilder(args);

var gestorReservas = new GestorReservas();

// Agrego los tours utilizando el método de agregar tour

gestorReservas.AgregarTour(new Tour
    {
        Id = 1,
        Nombre = "Explorando Buenos Aires",
        Destino = "Buenos Aires, Argentina",
        FechaInicio = new DateOnly(2024, 6, 10),
        FechaFin = new DateOnly(2024, 6, 15),
        Precio = 1500.00f
    }
);

gestorReservas.AgregarTour(new Tour
    {
        Id = 2,
        Nombre = "Descubriendo Patagonia",
        Destino = "Patagonia, Argentina",
        FechaInicio = new DateOnly(2024, 7, 5),
        FechaFin = new DateOnly(2024, 7, 12),
        Precio = 2000.00f
    }
);

gestorReservas.AgregarTour(new Tour
    {
        Id = 3,
        Nombre = "Aventura en las Cataratas del Iguazú",
        Destino = "Cataratas del Iguazú, Argentina",
        FechaInicio = new DateOnly(2024, 8, 20),
        FechaFin = new DateOnly(2024, 8, 25),
        Precio = 1800.00f
    }
);

gestorReservas.AgregarTour(new Tour
{
    Id = 4,
    Nombre = "Excursión al Glaciar Perito Moreno",
    Destino = "El Calafate, Argentina",
    FechaInicio = new DateOnly(2024, 9, 5),
    FechaFin = new DateOnly(2024, 9, 10),
    Precio = 2200.00f
});

gestorReservas.AgregarTour(new Tour
{
    Id = 5,
    Nombre = "Recorrido por las Ruinas de Machu Picchu",
    Destino = "Cusco, Perú",
    FechaInicio = new DateOnly(2024, 10, 15),
    FechaFin = new DateOnly(2024, 10, 20),
    Precio = 2500.00f
});

gestorReservas.AgregarTour(new Tour
{
    Id = 6,
    Nombre = "Aventura en el Desierto del Sahara",
    Destino = "Marruecos",
    FechaInicio = new DateOnly(2024, 11, 5),
    FechaFin = new DateOnly(2024, 11, 12),
    Precio = 2800.00f
});

// Agrego las reservas utilizando el método de agregar reserva

gestorReservas.ReservarTour(new Reserva
    {
        Id = 1,
        Cliente = "Juan Perez",
        FechaReserva = new DateOnly(2024, 6, 8),
        TourId = 1
    }
);
gestorReservas.ReservarTour(new Reserva
    {
        Id = 2,
        Cliente = "María García",
        FechaReserva = new DateOnly(2024, 7, 3),
        TourId = 2
    }
);
gestorReservas.ReservarTour(new Reserva
    {
        Id = 3,
        Cliente = "Carlos Rodríguez",
        FechaReserva = new DateOnly(2024, 8, 18),
        TourId = 2
    }
);
gestorReservas.ReservarTour(new Reserva
    {
        Id = 4,
        Cliente = "Ana Martínez",
        FechaReserva = new DateOnly(2024, 7, 10),
        TourId = 1
    }
);
gestorReservas.ReservarTour(new Reserva
    {
        Id = 5,
        Cliente = "Pedro López",
        FechaReserva = new DateOnly(2024, 8, 23),
        TourId = 3
    }
);

builder.Services.AddSingleton(gestorReservas);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
