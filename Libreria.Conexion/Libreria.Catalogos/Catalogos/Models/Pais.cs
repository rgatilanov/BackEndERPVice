using Libreria.ERP.Catalogos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.ERP.Catalogos.Models
{
    public class Pais : IPais
    {
        public int IdPais { get; set; }
        public string? NombrePais { get; set; }
        public string? InicialesPais { get; set; }
        public bool ValorDefaultPais { get; set; }
    }
}
