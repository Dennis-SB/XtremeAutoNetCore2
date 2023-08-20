namespace Front_End.Models
{
    public class ColorViewModel
    {
        public int ColorId { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Imagen { get; set; } = null!;
        public IFormFile? FormFile { get; set; }
    }
}
