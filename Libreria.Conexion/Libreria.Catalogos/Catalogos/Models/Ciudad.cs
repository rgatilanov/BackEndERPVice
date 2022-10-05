using Libreria.ERP.Catalogos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.ERP.Catalogos.Models
{
    public class Ciudad : ICiudad
    {
        public int IdCiudad { get; set; }
        public string? NombreCiudad { get; set; }
        public string? InicialesCiudad { get; set; }
        public Estado? Estado { get; set; }
        public bool ValorDefaultCiudad { get; set; }
    }
}
