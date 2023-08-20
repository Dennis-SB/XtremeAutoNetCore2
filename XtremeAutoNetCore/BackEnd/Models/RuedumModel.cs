namespace BackEnd.Models
{
    public class RuedumModel
    {
        public int RuedaId { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; }
        public string? Imagen { get; set; }
    }
}
