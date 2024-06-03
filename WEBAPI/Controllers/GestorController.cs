using Microsoft.AspNetCore.Mvc;
using WEBAPI.Domain;

[ApiController]
[Route("api/[controller]")]
public class GestorController : ControllerBase
{
    private readonly GestorReservas _gestorReservas;

    public GestorController(GestorReservas gestorReservas)
    {
        _gestorReservas = gestorReservas;
    }

    [HttpGet("MostrarTours")]
    public IActionResult MostrarTours(int? id = null)
    {
        IEnumerable<Tour> tours;

        if (id.HasValue)
        {
            tours = _gestorReservas.Tours.Where(tour => tour.Id == id);
        }
        else
        {
            tours = _gestorReservas.Tours;
        }

        return Ok(tours);
    }

    [HttpGet("MostrarReservas")]
    public IActionResult MostrarReservas(int? id = null)
    {
        IEnumerable<Reserva> reservas;

        if (id.HasValue)
        {
            reservas = _gestorReservas.Reservas.Where(reserva => reserva.Id == id);
        }
        else
        {
            reservas = _gestorReservas.Reservas;
        }

        return Ok(reservas);
    }

    [HttpDelete("eliminarreserva/{id}")]
    public IActionResult EliminarViaje(int id)
    {
        _gestorReservas.EliminarReserva(id);

        return NoContent();
    }
}