namespace FrontEnd.Models
{
    public class CarroVendidoViewModel
    {
        public int CarroVendidoId { get; set; }
        public int RuedaId { get; set; }
        public IEnumerable<RuedumViewModel> Ruedas { get; set; }
        public int ColorId { get; set; }
        public IEnumerable<ColorViewModel> Colores { get; set; }
        public int CarroModeloId { get; set; }
        public IEnumerable<CarroModeloViewModel> CarroModelos { get; set; }
        public int SeguroId { get; set; }
        public IEnumerable<SeguroViewModel> Seguros { get; set; }
        public decimal PrecioTotal { get; set; }
    }
}
