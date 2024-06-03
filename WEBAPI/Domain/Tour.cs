namespace WEBAPI.Domain
{
    public class Tour
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Destino { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFin { get; set; }
        public float Precio { get; set; }

        public Tour MostrarInformacion()
        {
            Tour tour = new Tour();
            return tour;
        }
    }
}
