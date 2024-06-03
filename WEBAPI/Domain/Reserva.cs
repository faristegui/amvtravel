using System.Runtime.InteropServices;

namespace WEBAPI.Domain
{
    public class Reserva
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public DateOnly FechaReserva { get; set; }
        public int TourId { get; set; }

        public Reserva MostrarInformacion()
        {
            Reserva reserva = new Reserva();
            return reserva;
        }
    }
}
