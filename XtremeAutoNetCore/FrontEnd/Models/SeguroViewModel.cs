namespace FrontEnd.Models
{
    public class SeguroViewModel
    {
        public int SeguroId { get; set; }
        public string Nombre { get; set; } = null!;
        public int Plazo { get; set; }
        public decimal Precio { get; set; }
    }
}
