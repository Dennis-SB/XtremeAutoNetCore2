namespace FrontEnd.Models
{
    public class TransaccionViewModel
    {
        public int TransaccionId { get; set; }
        public int VentaId { get; set; }
        public IEnumerable<VentumViewModel> Ventas { get; set; }
        public int? TarjetaId { get; set; }
        public IEnumerable<TarjetumViewModel> Tarjetas { get; set; }
        public DateTime? FechaTransaccion { get; set; }
        public DateTime FechaCorte { get; set; }
        public decimal InteresesMorosidad { get; set; }
        public bool Pagado { get; set; }
        public decimal Precio { get; set; }
    }
}