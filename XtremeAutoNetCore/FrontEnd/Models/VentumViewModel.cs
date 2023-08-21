namespace FrontEnd.Models
{
    public class VentumViewModel
    {
        public int VentaId { get; set; }
        public int UsuarioId { get; set; }
        public IEnumerable<UsuarioViewModel> Usuarios { get; set; }
        public int CarroVendidoId { get; set; }
        public IEnumerable<CarroVendidoViewModel> CarroVendidos { get; set; }
        public decimal Total { get; set; }
        public int Meses { get; set; }
        public decimal Intereses { get; set; }
        public decimal SaldoPendiente { get; set; }
        public decimal SaldoAbonado { get; set; }
    }
}
