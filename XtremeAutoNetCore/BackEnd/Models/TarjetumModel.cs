namespace BackEnd.Models
{
    public class TarjetumModel
    {
        public int TarjetaId { get; set; }
        public string UsuarioId { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string NumeroDeTarjeta { get; set; } = null!;
        public string Cvv { get; set; } = null!;
        public DateTime FechaVencimiento { get; set; }
        public bool LockoutEnabled { get; set; }
    }
}
