using Libreria.ERP.Catalogos;
using Libreria.ERP.Catalogos.Interfaces;
using Libreria.ERP.Catalogos.Models;
using Libreria.ERP.Catalogos.Services;
using Libreria.ERP.Catalogos.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.Common;

namespace ERP_WebAPI.Controllers.API
{
    public class CatalogoAPIController : ControllerBase
    {
        //[Authorize]
        ///https://localhost:5001/api/Catalogo/ConsultarCiudades?IdEstado=14
        [HttpGet]
        [Route("api/Catalogo/ConsultarCiudades")]
        public ActionResult<Ciudad> ConsultarCiudades(int IdEstado)
        {
            if (IdEstado == 0)
                return BadRequest("Ingrese IdEstado válido");

            Ciudad model = new Ciudad();
            using(ICiudadService iObj = FactorizadorCatalogo.Inicializar(Libreria.ERP.Configuracion.EServer.LOCAL_SQL))
            {
                return model = (Ciudad)iObj;
            }

            throw new Exception("Error en método");
        }

    }
}
