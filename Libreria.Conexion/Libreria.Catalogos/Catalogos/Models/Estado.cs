using Libreria.ERP.Catalogos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.ERP.Catalogos.Models
{
    public class Estado : IEstado
    {
        public int IdEstado { get; set; }
        public string? NombreEstado { get; set; }
        public string? InicialesEstado { get; set; }
        public int CodigoINEGIEstado { get; set; }
        public IPais Pais { get; set; } = new Pais();
        public bool ValorDefaultEstado { get; set; }
    }
}
