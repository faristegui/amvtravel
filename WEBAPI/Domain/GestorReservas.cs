using Microsoft.VisualBasic;

namespace WEBAPI.Domain
{
    public class GestorReservas
    {
        public List<Tour>? Tours { get; set; } = new List<Tour>();

        public List<Reserva>? Reservas { get; set; } = new List<Reserva>();

        public void AgregarTour(Tour tour)
        {
            Tours.Add(tour);
        }
        public List<Tour> MostrarTours()
        {
            return Tours;
        }
        public void ReservarTour(Reserva reserva)
        {
            Reservas.Add(reserva);
        }
        public List<Reserva> MostrarReservas()
        {
            return Reservas;
        }
        public void EliminarReserva(int idReserva)
        {
            Reservas.RemoveAll(reserva => reserva.Id == idReserva);
        }
    }
}
