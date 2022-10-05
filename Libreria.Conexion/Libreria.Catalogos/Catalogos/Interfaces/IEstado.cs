using Libreria.ERP.Catalogos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.ERP.Catalogos.Interfaces
{
    public interface IEstado
    {
        public int IdEstado { get; set; }
        public string NombreEstado { get; set; }
        public string InicialesEstado { get; set; }
        public int CodigoINEGIEstado { get; set; }
        public Pais Pais { get; set; } 
        public Boolean ValorDefaultEstado { get; set; }
    }
}
