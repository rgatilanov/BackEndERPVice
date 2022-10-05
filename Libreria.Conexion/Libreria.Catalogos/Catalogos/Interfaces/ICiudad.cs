using Libreria.ERP.Catalogos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.ERP.Catalogos.Interfaces
{
    public interface ICiudad
    {
        public int IdCiudad { get; set; }
        public string NombreCiudad { get; set; }
        public string InicialesCiudad { get; set; }
        public Estado Estado { get; set; }
        public Boolean ValorDefaultCiudad { get; set; }
    }
}
