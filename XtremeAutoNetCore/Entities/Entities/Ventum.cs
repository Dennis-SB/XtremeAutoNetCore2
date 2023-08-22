using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Ventum
    {
        public Ventum()
        {
            Transaccions = new HashSet<Transaccion>();
        }

        public int VentaId { get; set; }
        public string UsuarioId { get; set; } = null!;
        public int CarroVendidoId { get; set; }
        public decimal Total { get; set; }
        public int Meses { get; set; }
        public decimal Intereses { get; set; }
        public decimal SaldoPendiente { get; set; }
        public decimal SaldoAbonado { get; set; }

        public virtual CarroVendido CarroVendido { get; set; } = null!;
        public virtual AspNetUser Usuario { get; set; } = null!;
        public virtual ICollection<Transaccion> Transaccions { get; set; }
    }
}