namespace Front_End.Models
{
    public class RuedaViewModel
    {
        public int RuedaId { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Imagen { get; set; } = null!;
        public decimal Precio { get; set; }
    }
}
