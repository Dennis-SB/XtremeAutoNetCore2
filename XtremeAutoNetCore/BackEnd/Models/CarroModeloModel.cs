﻿namespace BackEnd.Models
{
    public class CarroModeloModel
    {
        public int CarroModeloId { get; set; }
        public bool Disponible { get; set; }
        public string Tipo { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public string Modelo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public string? Imagen { get; set; }
    }
}
