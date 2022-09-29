using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.ERP.Catalogos.Interfaces
{
    public interface IPais
    {
        public int IdPais { get; set; }
        public string NombrePais { get; set; }
        public string InicialesPais { get; set; }
        public Boolean ValorDefaultPais { get; set; }
    }
}
